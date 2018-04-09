using Bocom.ImageAnalysisClient.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Bocom.ImageAnalysisClient.Service.DAO;
using WinFormAppUtil;

namespace Bocom.ImageAnalysisClient.Service
{
    public class ImageAnalysisService
    {
        #region Events & fields

        //public event Action<uint, string> Message;
        //public event Action<AnalyseRecord> AnalyseResult;
        //public event Action<Analyse_ResultByFile, IntPtr> AnalyseResultsByFile;
        //public event Action<Analyse_ResultByFile, IntPtr> AnalyseCompareResult;
        //public event Action<int> PicturesRequest;

        
        //private TFuncCtrlMsgNtfCB m_funcOnCtrlMsg;
        //private TFuncAnalyseResultNtfCB m_funcOnAnaResult;
        //private TFuncAnalyseResultByFileNtfCB m_funcOnAnaResultByFile;
        //private TFuncRequestPicturesNtfCB m_funcOnRequestPictures;

        private bool m_Running;

        #endregion

        #region Constructors

        public ImageAnalysisService()
        {
            //m_funcOnCtrlMsg = OnCtrlMsg;
            //m_funcOnAnaResult = OnAnaResult;
            //m_funcOnRequestPictures = OnRequestPictures;
            //m_funcOnAnaResultByFile = OnAnaResultByFile;

            //InteropService.SetAnalyseResultNtfCB(m_funcOnAnaResult);
            //InteropService.SetAnalyseResultByFileNtfCB(m_funcOnAnaResultByFile);
            //InteropService.SetCtrlMsgNtfCB(m_funcOnCtrlMsg);
            //InteropService.SetPicturesRequestNtfCB(m_funcOnRequestPictures);
            System.Diagnostics.Trace.WriteLine("InteropService.SetNtfCB ret:" + "void");
            
        }

        #endregion
        
        public bool Running
        {
            get { return m_Running; }
        }
        
        #region Task related functions
              
        #endregion

        #region Public helper functions

        public bool Start(bool force = false)
        {
            return true;
            //if (!force)
            //{
            //    if (!m_Running)
            //    {
            //        m_Running = InteropService.StartAnalysis();
            //        System.Diagnostics.Trace.WriteLine("InteropService.StartAnalysis ret:" + m_Running);

            //    }
            //    return m_Running;
            //}
            //bool nRet = InteropService.StartAnalysis();
            //System.Diagnostics.Trace.WriteLine("InteropService.StartAnalysis ret:" + nRet);

            //return nRet;
        }

        public void Stop()
        {
            
            //m_Running = false;
            //bool nRet = InteropService.StopAnalysis();
            //System.Diagnostics.Trace.WriteLine("InteropService.StopAnalysis ret:" + nRet);

        }

        public bool ReConnect()
        {
            bool bRet = false;

            //bRet = InteropService.ReConnect();
            //System.Diagnostics.Trace.WriteLine("InteropService.ReConnect ret:" + bRet);

            //MyLog4Net.Container.Instance.Log.InfoFormat("重连 {0}", bRet ? "成功" : "失败");

            return bRet;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> 设置检测区域 (标定) </summary>
        ///
        /// <remarks>   Administrator, 2014/11/12. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetVehicleRecognitionArea()
        {

        }

        public void AddLocalFolder(string folder)
        {
            //InteropService.AddLocalFolder(folder);
            //System.Diagnostics.Trace.WriteLine("InteropService.AddLocalFolder ret:" + "void");

        }

        public bool SendPictureItems(AnalyseTask task, PictureItem[] items)
        {
            return true;
            //Analyse_Task analys_Task = new Analyse_Task();
            //task.ParseTo(ref analys_Task);
            //IntPtr ptr = GetPictureItemPtr(task.FileType,items);

            //bool result = InteropService.SendPictures(analys_Task, ptr, items.Length);
            //System.Diagnostics.Trace.WriteLine("InteropService.SendPictures ret:" + result);

            //Marshal.FreeHGlobal(ptr);
            //return result;
        }

        #endregion
        
        //private static IntPtr GetPictureItemPtr(FileType fileType, PictureItem[] items)
        //{
        //    IntPtr temp = IntPtr.Zero;

        //    temp = Marshal.AllocHGlobal(items.Length * Marshal.SizeOf(typeof(PicParam)));
        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        PicParam picParam = new PicParam() { FileType = (uint)fileType, FilePath = items[i].FullName };
        //        Marshal.StructureToPtr(picParam, temp + i * Marshal.SizeOf(typeof(PicParam)), false);
        //    }
        //    return temp;
        //}

        //#region Event handlers

        //private void OnCtrlMsg(NETSDK_CTRL_MSG ctrlMsg)
        //{
        //    if(Message != null)
        //    {
        //        Message(ctrlMsg.Type, ctrlMsg.Message);
        //    }
        //}

        //private void OnAnaResult(Analyse_Result result)
        //{
        //    if (AnalyseResult != null)
        //    {
        //        AnalyseRecord record = new AnalyseRecord();
        //        record.ParseFrom(result);
        //        AnalyseResult(record);
        //    }
        //}

        //private void OnAnaResultByFile(Analyse_ResultByFile result, IntPtr pResults)
        //{
        //    System.Diagnostics.Trace.WriteLine("OnAnaResultByFile id =" + result.PicId + ";count=" + result.Count);
        //    if (result.PicId.ToLower() == System.IO.Path.GetTempPath().ToLower() + "compare.jpg##" + int.MaxValue)
        //    {
        //        if (AnalyseCompareResult != null)
        //        {
        //            AnalyseCompareResult(result, pResults);
        //        }
        //    }
        //    else
        //    {
        //        if (AnalyseResultsByFile != null)
        //        {
        //            AnalyseResultsByFile(result, pResults);
        //        }
        //    }
        //}

        //private void OnRequestPictures(int count)
        //{
        //    if(PicturesRequest != null)
        //    {
        //        PicturesRequest(count);
        //    }
        //}

        //#endregion
    }
}
