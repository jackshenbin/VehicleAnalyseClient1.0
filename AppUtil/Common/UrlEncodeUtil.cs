using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace AppUtil.Common
{
    public static class UrlEncodeUtil
    {
        static string MyGBKEncoder(Match match)
        {
            return System.Web.HttpUtility.UrlEncode(match.Value, System.Text.Encoding.GetEncoding("gbk"));
        }
        static string MyUTF8Encoder(Match match)
        {
            return System.Web.HttpUtility.UrlEncode(match.Value, System.Text.Encoding.UTF8);
        }

        public static string UrlPathEncode(string url, EncodingType encoding)
        {
            switch (encoding)
            {
                case EncodingType.GBK:
                    url = Regex.Replace(url, @"[\u4e00-\u9fa5]+", new MatchEvaluator(MyGBKEncoder));
                    break;
                case EncodingType.UTF8:
                    url = Regex.Replace(url, @"[\u4e00-\u9fa5]+", new MatchEvaluator(MyUTF8Encoder));
                    break;
                default:
                    break;
            }

            return url;
        }

        public enum EncodingType
        {
            GBK,
            UTF8,
        }
    }


}
