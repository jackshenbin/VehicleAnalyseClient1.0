using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using DevExpress.Office.Utils;
using Bocom.ImageAnalysisClient.Service.DAO;
using System.IO;

namespace Bocom.ImageAnalysisClient.App
{
    public partial class FormVehicleBrandManagement : DevExpress.XtraEditors.XtraForm
    {

        private VehicleBrand m_EditBrand;

        private Dictionary<int, Tuple<int, VehicleBrand>> m_DTBrand2Range = new Dictionary<int, Tuple<int, VehicleBrand>>();

        public FormVehicleBrandManagement()
        {
            InitializeComponent();
        }

           private void ProcessParentBrand(List<string> lines)
           {
           
           }

           private void ProcessChildBrand(List<string> lines)
           {

           }

        private void AddBrand(string name, string sId)
        {
            int parentId = (int)spinEditLocalPort.Value;

            int id = -1;
            if (int.TryParse(sId, out id))
            {
                Framework.Container.Instance.TaskManager.AddVehicleBrand(name, id, parentId);
            }
            else
            {
                Debug.Assert(false);
            }
        }

        private bool GetIds(string sLine, out int parentId, out int startId)
        {
            bool bRet = false;
            int index = sLine.IndexOf("," );
            parentId = -1; startId = -1;
            if(index > 0 && sLine.LastIndexOf(",") == index)
            {
                string[] ids = sLine.Split(",".ToCharArray());
                if (int.TryParse(ids[0], out parentId) && int.TryParse(ids[1], out startId))
                {
                    foreach (KeyValuePair<int, Tuple<int, VehicleBrand>> kv in m_DTBrand2Range)
                    {
                        if (startId >= kv.Key && startId <= kv.Value.Item1)
                        {
                            parentId =(int) kv.Value.Item2.Id;
                            bRet = true;
                            break;
                        }
                    }

                }
            }
            return bRet;
        }

        private bool GetIds(string sLine, out int parentId, out int startId, out VehicleBrand parentBrand)
        {
            bool bRet = false;
            int index = sLine.IndexOf(",");
            parentBrand = null;
            parentId = -1; startId = -1;
            if (index > 0 && sLine.LastIndexOf(",") == index)
            {
                string[] ids = sLine.Split(",".ToCharArray());
                if (int.TryParse(ids[0], out parentId) && int.TryParse(ids[1], out startId))
                {
                    foreach (KeyValuePair<int, Tuple<int, VehicleBrand>> kv in m_DTBrand2Range)
                    {
                        if (startId >= kv.Key && startId <= kv.Value.Item1)
                        {
                            parentId = (int)kv.Value.Item2.Id;
                            parentBrand = kv.Value.Item2;
                            bRet = true;
                            break;
                        }
                    }

                }
            }
            return bRet;
        }

        private bool ParseChildBrandLine(string content, ref string parentName, out string name)
        {
            // 开始处理子品牌行
            bool bRet = false;
            int start = content.IndexOf("\"");
            int end = content.LastIndexOf("\"");
            name = string.Empty;

            if (start > -1 && start != end)
            {
                bRet = true;

                string temp = content.Substring(start + 1, end - start - 1);

                if (string.IsNullOrEmpty(parentName))
                {
                    start = temp.IndexOf(" ");
                    if (start > -1)
                    {
                        parentName = temp.Substring(0, start);
                    }
                    else
                    {
                        parentName = temp;
                    }
                }

                name = temp;
                if (temp.StartsWith(parentName))
                {
                    name = temp.Substring(parentName.Length).Trim();
                }
            }

            return bRet;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string text = richTextBox2.Text.Trim();

            System.IO.StringReader sr = new System.IO.StringReader(text);
            bool hasIdInfo = false;
            int parentId = -1, startId = -1;
            string parentName = string.Empty;
            List<int> modelIds = new List<int>();
            int lineNO = 0;
            VehicleBrand parentBrand = null;
            bool parentBrandLineMeet = false;
            bool childBrandLineMeet = false;
            List<string> lines = new List<string>();

            while(true)
            {
                string line = sr.ReadLine();
                lineNO++;
             
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(string.Format("# Line {0}: {1}", lineNO, line));

                line = line.Trim();
                if (line.Length == 0)
                {
                    Console.WriteLine("Skip");
                    continue;
                }

                if (childBrandLineMeet && string.Compare(line, "};", true) == 0)
                {
                    ProcessChildBrand(lines);
                }

                if (!parentBrandLineMeet && string.Compare(line, "// 一级品牌", true) == 0)
                {
                    parentBrandLineMeet = true;
                    continue;
                }
                if (!parentBrandLineMeet)
                {
                    continue;
                }

                if (!childBrandLineMeet && string.Compare(line, "// 二级品牌", true) == 0)
                {
                    childBrandLineMeet = true;
                    ProcessParentBrand(lines);
                    lines.Clear();
                }

                if (!childBrandLineMeet)
                {
                    lines.Add(line);
                    // ProcessParentBrand(line, sr);
                }
                else
                {
                    
                    lines.Add(line);
                    // ProcessChildBrand(line, sr);
                }

                if (!hasIdInfo)
                {
                    Debug.Assert(!line.StartsWith("\""));

                    hasIdInfo = GetIds(line, out parentId, out startId, out parentBrand);
                    if (hasIdInfo)
                    {
                        parentName = parentBrand.Name;
                        Console.WriteLine(string.Format("Got ids: {0}, {1}", parentId, startId));
                    }
                    continue;
                }
                
               

                /// 也有可能是一段新的车品牌
                int parentIdTmp, startIdTmp;
                if (GetIds(line, out parentIdTmp, out startIdTmp, out parentBrand))
                {
                    hasIdInfo = true;
                    parentId = parentIdTmp;
                    startId = startIdTmp;
                    
                    modelIds.Clear();
                    parentName = parentBrand.Name; // string.Empty;
                    Console.WriteLine(string.Format("Got ids: {0}, {1}", parentId, startId)); 
                    continue;
                }

                if (!line.StartsWith("\""))
                {
                    hasIdInfo = false;
                    modelIds.Clear();
                    parentName = string.Empty;
                    Console.WriteLine("Skip and Reset");
                    continue;
                }
                
                string name;
                // parentName = parentBrand.Name;

                if (ParseChildBrandLine(line, ref parentName, out name))
                {
                    // 处理 父Id 是 999的问题
                    //if (parentId <= 154)
                    //{
                    //    continue;
                    //}

                    //Debug.Assert(parentId == 999);

                    // Debug.Assert(!string.IsNullOrEmpty(parentName) && !string.IsNullOrEmpty(name));

                    if (!modelIds.Contains(startId))
                    {
                        // Framework.Container.Instance.TaskManager.AddVehicleBrand(parentName, parentId, name, startId);
                        //if (parentName == "日产")
                        //{
                        //    parentName = "尼桑";
                        //}
                        if (string.IsNullOrEmpty(name))
                        {
                            name = parentName;
                        }
                        Framework.Container.Instance.TaskManager.AddVehicleBrand(name, startId, parentId);
                        // Framework.Container.Instance.TaskManager.UpdateVehicleBrand(parentName, parentId, name, startId);
                        modelIds.Add(startId);
                        Console.WriteLine(string.Format("Add child brand: parentname {0}, parentId {1}, name {2}, id {3}",
                            parentName, parentId, name, startId));
                    }
                    else
                    {
                        Console.WriteLine("Debug Fail");
                        Debug.Assert(false);
                    }
                    startId++;
                }
                else
                {
                    hasIdInfo = false;

                    modelIds.Clear();
                    parentName = string.Empty;
                    Console.WriteLine("Skip and Reset");
                    continue;
                }
            }



            //string idInfo = sr.ReadLine();
            //string[] ids = idInfo.Split(",".ToCharArray());
            //int parent = 0, startId = 0;
            //string parentName = null;
            
            //if (int.TryParse(ids[0], out parent) && int.TryParse(ids[1], out startId))
            //{
            //    string temp, name;
            //    int start, end;
            //    while (true)
            //    {
            //        temp = sr.ReadLine();
            //        if(!string.IsNullOrEmpty(temp))
            //        {
            //            start = temp.IndexOf("\"");
            //            end = temp.LastIndexOf("\"");
            //            temp = temp.Substring(start + 1, end - start - 1);

            //            if (parentName == null)
            //            {
            //                start = temp.IndexOf(" ");
            //                if (start > -1)
            //                {
            //                    parentName = temp.Substring(0, start);
            //                }
            //                else
            //                {
            //                    parentName = temp;
            //                }
            //            }
            //            if (temp.StartsWith(parentName))
            //            {
            //                name = temp.Substring(parentName.Length).Trim();
            //            }
            //            else
            //            {
            //                name = temp;
            //            }

            //            if (!modelIds.Contains(startId))
            //            {
            //                Framework.Container.Instance.TaskManager.AddVehicleBrand(parentName, parent, name, startId);
            //                modelIds.Add(startId);
            //            }
            //            else
            //            {
            //                Debug.Assert(false);
            //            }
            //            startId++;
            //        }
            //        else if (temp == string.Empty)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

            MessageBox.Show(string.Format("{0} 条记录添加成功", modelIds.Count));

            sr.Close();
            sr.Dispose();


            if (!string.IsNullOrEmpty(text))
            {
                // string[] segs = text.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                // text = text.Replace("\n", string.Empty);
                //text = text.Replace("\t", string.Empty);
                //string[] segs = text.Split("\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //if (segs != null && segs.Length > 0)
                //{
                //    string sId, sName;
                //    for (int i = 0; i < segs.Length; i++)
                //    {
                //        sName = segs[i].Trim().Replace("\t", string.Empty);
                //        string tt = Regex.Replace(sName, "[ ]+", " ");
                //        sId = segs[i + 1];
                //        AddBrand(tt, sId);
                //        i++;
                //    }
                //}

                //string[] segs = text.Split("\n%,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //if (segs != null && segs.Length > 0)
                //{
                //    string sId, sName;
                //    for (int i = 0; i < segs.Length; i++)
                //    {
                //        string[] tmps = segs[i].Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                //        AddBrand(tmps[0].Trim(), tmps[1].Trim());
                //        i++;
                //    }
                //}

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string text = richTextBox2.Text.Trim();

            System.IO.StringReader sr = new System.IO.StringReader(text);
            bool hasIdInfo = false;
            int parentId = -1, startId = -1;
            string parentName = string.Empty, name= string.Empty, sId = string.Empty;
            List<int> modelIds = new List<int>();
            int lineNO = 0;

            while (true)
            {
                string line = sr.ReadLine();
                lineNO++;
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(string.Format("# Line {0}: {1}", lineNO, line));

                line = line.Trim();
                if (line.Length == 0)
                {
                    Console.WriteLine("Skip");
                    continue;
                }

                line = line.Trim("/".ToCharArray());
                int index = line.LastIndexOf(" ");
                if (index > -1)
                {
                    name = line.Substring(0, index).Trim();
                    sId = line.Substring(index + 1);
                }
                else
                {
                    index = line.LastIndexOf("\t");
                    if (index > -1)
                    {
                        name = line.Substring(0, index).Trim("\t".ToCharArray());
                        sId = line.Substring(index + 1);
                    }
                }
                if (int.TryParse(sId, out startId))
                {
                    Framework.Container.Instance.TaskManager.AddVehicleBrand(name, startId, -1);
                     Console.WriteLine(string.Format("Add brand: name {0}, id {1}",name, startId));
                }
                else
                {
                    Debug.Assert(false);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            m_DTBrand2Range.Clear();
            string text = richTextBox2.Text.Trim();

            System.IO.StringReader sr = new System.IO.StringReader(text);
            bool hasIdInfo = false;
            int parentId = -1, startId = -1;
            string parentName = string.Empty, name = string.Empty, sId = string.Empty;
            VehicleBrand brand;
            List<int> modelIds = new List<int>();
            int lineNO = 0;

            while (true)
            {
                string line = sr.ReadLine();
                lineNO++;
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(string.Format("# Line {0}: {1}", lineNO, line));

                line = line.Trim();
                if (line.Length == 0)
                {
                    Console.WriteLine("Skip");
                    continue;
                }

                string[] segs = line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (segs.Length == 3)
                {
                    int min, max, index;
                    if (int.TryParse(segs[0], out min) && int.TryParse(segs[1], out max))
                    {
                        index = segs[2].IndexOf("\"");
                        name = segs[2].Substring(index + 1, segs[2].LastIndexOf("\"") - index - 1);
                        if (name.Contains("日产"))
                        {
                            name = "尼桑";
                        }
                        else if (name == "雪佛兰")
                        {
                            name = "雪弗兰";
                        }
                        else if (name == "雷克萨斯")
                        {
                            name = "丰田";
                        }
                        else if (name == "凯蒂拉客")
                        {
                            name = "凯迪拉克";
                        }
                        //else if (name == "名爵")
                        //{
                        //    name = "名爵";
                        //}
                        //else if (name == "东南")
                        //{
                        //    name = "东南 东南汽车";
                        //}
                        //else if (name == "福迪")
                        //{
                        //    name = "福迪汽车";
                        // }
                        else if (name == "海马")
                        {
                            name = "海马郑州";
                        }
                        else if (name == "中华")
                        {
                            name = "华晨";
                        }
                        else if (name == "南京")
                        {
                            name = "其它";
                        }
                        //else if (name == "羊城")
                        //{
                        //    name = "羊城汽车";
                        //}
                        //else if (name == "众泰")
                        //{
                        //    name = "众泰 众泰汽车";
                        //}
                        else if (name == "哈弗")
                        {
                            name = "长城";
                        }
                        else if (name == "精灵")
                        {
                            name = "长城";
                        }
                        else if (name == "凯马")
                        {
                            name = "其它";
                        }
                        else if (name == "宇通")
                        {
                            name = "宇通客车";
                        }
                        else if (name == "江淮汽车")
                        {
                            name = "江淮";
                        }
                        else if (name.Contains("申通"))
                        {
                            name = "其它";
                        }
                        else if (name == "江淮汽车")
                        {
                            name = "江淮";
                        }
                        else if (name == "金龙客车")
                        {
                            name = "金龙";
                        }
                        else if (name == "飞驰")
                        {
                            name = "佛山飞驰";
                        }
                        
                        brand = Framework.Container.Instance.TaskManager.GetBrand(name);

                        if (brand == null)
                        {
                            brand = Framework.Container.Instance.TaskManager.GetBrand("其它");
                        }

                        // Console.WriteLine(string.Format("Got brand id name {0}, mix {1}, max {2}, result: {3}", name, min, max, brand != null));
                        Debug.Assert(brand != null);
                        if (brand != null)
                        {
                            m_DTBrand2Range.Add(min, new Tuple<int, VehicleBrand>(max, brand));
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Not found brand id name {0}, mix {1}, max {2}", name, min, max));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Parse failed");
                    }
                }
                else
                {
                    Debug.Assert(false);
                    Console.WriteLine("Parse failed");
                }
                //line = line.Trim("/".ToCharArray());
                //int index = line.LastIndexOf(" ");
                //if (index > -1)
                //{
                //    name = line.Substring(0, index).Trim();
                //    sId = line.Substring(index + 1);
                //}
                //else
                //{
                //    index = line.LastIndexOf("\t");
                //    if (index > -1)
                //    {
                //        name = line.Substring(0, index).Trim("\t".ToCharArray());
                //        sId = line.Substring(index + 1);
                //    }
                //}
                //if (int.TryParse(sId, out startId))
                //{
                //    Framework.Container.Instance.TaskManager.AddVehicleBrand(name, startId, -1);
                //    Console.WriteLine(string.Format("Add brand: name {0}, id {1}", name, startId));
                //}
              
            }
        }

        private void btnGetBrandInfo_Click(object sender, EventArgs e)
        {
            m_EditBrand = Framework.Container.Instance.TaskManager.GetBrand((int)spinEditBrandId.Value);
            if (m_EditBrand == null)
            {
                textEdit1.Text = string.Empty;
                spinEditParent.EditValue = -1;
            }
            else
            {
                textEdit1.Text = m_EditBrand.Name;
                spinEditParent.EditValue = m_EditBrand.ParentId;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
    }
}