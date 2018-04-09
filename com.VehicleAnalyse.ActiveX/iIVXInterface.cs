using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace com.VehicleAnalyse.ActiveX
{
    [Guid("9199C368-BA96-4D75-985D-0980AD27123E"),
    InterfaceType(ComInterfaceType.InterfaceIsDual),
    ComVisible(true)]
    public interface iIRASInterface
    {
        #region 基础操作

        /// <summary>
        /// 控件初始化，该接口直接使用最高权限登录到系统中。
        /// </summary>
        /// <returns>xml返回
        /// <Ret>
        /// <RetMsg><ErrorCode></ErrorCode><Description></Description></RetMsg>
        /// <RetInfo></RetInfo>
        /// </Ret>
        /// 
        /// </returns>
        string IRASInitialization();



        /// <summary>
        /// 控件反初始化
        /// </summary>
        /// <returns>xml返回
        /// <Ret>
        /// <RetMsg><ErrorCode></ErrorCode><Description></Description></RetMsg>
        /// <RetInfo></RetInfo>
        /// </Ret>
        /// 
        /// </returns>
        string IRASUninitialization();

        /// <summary>
        /// 获取程序版本号
        /// </summary>
        /// <returns>xml返回
        /// <Ret>
        /// <RetMsg><ErrorCode></ErrorCode><Description></Description></RetMsg>
        /// <RetInfo>Version</RetInfo>
        /// </Ret>
        /// 
        /// </returns>
        string IRASGetVersion();

        #endregion
        
    }



    [ComVisible(true)]
    [Guid("F85F7951-67C1-4984-8F5E-69D13BF1B104")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRASEvents
    {
    }


    /// <summary>
    /// IObjectSafety接口.net定义
    /// </summary>
    [ComImport, GuidAttribute("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]//uuid
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]//继承了IUnknown
    public interface IObjectSafety
    {
        [PreserveSig]
        int GetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions,
            [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions);

        [PreserveSig()]
        int SetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask,
            [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions);
    }

}

