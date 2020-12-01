// <copyright file="NativeMethods.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using RohdeSchwarz.Iot.Middleware.Model;
using ViAttr = System.Int32;
using ViStatus = System.Int32;

// Naming Styles, Use built-in type alias,  Do not use regions, Missing XML comment for publicly visible type or member, Elements should be documented
#pragma warning disable IDE1006, SA1121, SA1124, CS1591, SA1600

namespace RohdeSchwarz.Iot.Middleware.Gateway.Internal
{
    /// <summary>
    /// Wrapper class for the native Visa.
    /// </summary>
    internal static class NativeMethods
    {
        #region - Constants -------------------------------------------------------------

        #region - Other VISA Definitions ------------------------------------------------
        public const short VI_FIND_BUFLEN = 256;
        public const short VI_NULL = 0;
        public const short VI_TRUE = 1;
        public const short VI_FALSE = 0;
        public const short VI_INTF_GPIB = 1;
        public const short VI_INTF_VXI = 2;
        public const short VI_INTF_GPIB_VXI = 3;
        public const short VI_INTF_ASRL = 4;
        public const short VI_INTF_TCPIP = 6;
        public const short VI_INTF_USB = 7;
        public const short VI_PROT_NORMAL = 1;
        public const short VI_PROT_FDC = 2;
        public const short VI_PROT_HS488 = 3;
        public const short VI_PROT_4882_STRS = 4;
        public const short VI_PROT_USBTMC_VENDOR = 5;
        public const short VI_FDC_NORMAL = 1;
        public const short VI_FDC_STREAM = 2;
        public const short VI_LOCAL_SPACE = 0;
        public const short VI_A16_SPACE = 1;
        public const short VI_A24_SPACE = 2;
        public const short VI_A32_SPACE = 3;
        public const short VI_OPAQUE_SPACE = -1;
        public const short VI_UNKNOWN_LA = -1;
        public const short VI_UNKNOWN_SLOT = -1;
        public const short VI_UNKNOWN_LEVEL = -1;
        public const short VI_QUEUE = 1;
        public const short VI_HNDLR = 2;
        public const short VI_SUSPEND_HNDLR = 4;
        public const short VI_ALL_MECH = -1;
        public const short VI_TRIG_ALL = -2;
        public const short VI_TRIG_SW = -1;
        public const short VI_TRIG_TTL0 = 0;
        public const short VI_TRIG_TTL1 = 1;
        public const short VI_TRIG_TTL2 = 2;
        public const short VI_TRIG_TTL3 = 3;
        public const short VI_TRIG_TTL4 = 4;
        public const short VI_TRIG_TTL5 = 5;
        public const short VI_TRIG_TTL6 = 6;
        public const short VI_TRIG_TTL7 = 7;
        public const short VI_TRIG_ECL0 = 8;
        public const short VI_TRIG_ECL1 = 9;
        public const short VI_TRIG_PANEL_IN = 27;
        public const short VI_TRIG_PANEL_OUT = 28;
        public const short VI_TRIG_PROT_DEFAULT = 0;
        public const short VI_TRIG_PROT_ON = 1;
        public const short VI_TRIG_PROT_OFF = 2;
        public const short VI_TRIG_PROT_SYNC = 5;
        public const short VI_READ_BUF = 1;
        public const short VI_WRITE_BUF = 2;
        public const short VI_READ_BUF_DISCARD = 4;
        public const short VI_WRITE_BUF_DISCARD = 8;
        public const short VI_IO_IN_BUF = 16;
        public const short VI_IO_OUT_BUF = 32;
        public const short VI_IO_IN_BUF_DISCARD = 64;
        public const short VI_IO_OUT_BUF_DISCARD = 128;
        public const short VI_FLUSH_ON_ACCESS = 1;
        public const short VI_FLUSH_WHEN_FULL = 2;
        public const short VI_FLUSH_DISABLE = 3;
        public const short VI_NMAPPED = 1;
        public const short VI_USE_OPERS = 2;
        public const short VI_DEREF_ADDR = 3;
        public const int VI_TMO_IMMEDIATE = 0;
        public const int VI_TMO_INFINITE = -1;
        public const short VI_NO_LOCK = 0;
        public const short VI_EXCLUSIVE_LOCK = 1;
        public const short VI_SHARED_LOCK = 2;
        public const short VI_LOAD_CONFIG = 4;
        public const short VI_NO_SEC_ADDR = -1;
        public const short VI_ASRL_PAR_NONE = 0;
        public const short VI_ASRL_PAR_ODD = 1;
        public const short VI_ASRL_PAR_EVEN = 2;
        public const short VI_ASRL_PAR_MARK = 3;
        public const short VI_ASRL_PAR_SPACE = 4;
        public const short VI_ASRL_STOP_ONE = 10;
        public const short VI_ASRL_STOP_ONE5 = 15;
        public const short VI_ASRL_STOP_TWO = 20;
        public const short VI_ASRL_FLOW_NONE = 0;
        public const short VI_ASRL_FLOW_XON_XOFF = 1;
        public const short VI_ASRL_FLOW_RTS_CTS = 2;
        public const short VI_ASRL_FLOW_DTR_DSR = 4;
        public const short VI_ASRL_END_NONE = 0;
        public const short VI_ASRL_END_LAST_BIT = 1;
        public const short VI_ASRL_END_TERMCHAR = 2;
        public const short VI_ASRL_END_BREAK = 3;
        public const short VI_STATE_ASSERTED = 1;
        public const short VI_STATE_UNASSERTED = 0;
        public const short VI_STATE_UNKNOWN = -1;
        public const short VI_BIG_ENDIAN = 0;
        public const short VI_LITTLE_ENDIAN = 1;
        public const short VI_DATA_PRIV = 0;
        public const short VI_DATA_NPRIV = 1;
        public const short VI_PROG_PRIV = 2;
        public const short VI_PROG_NPRIV = 3;
        public const short VI_BLCK_PRIV = 4;
        public const short VI_BLCK_NPRIV = 5;
        public const short VI_D64_PRIV = 6;
        public const short VI_D64_NPRIV = 7;
        public const short VI_WIDTH_8 = 1;
        public const short VI_WIDTH_16 = 2;
        public const short VI_WIDTH_32 = 4;
        public const short VI_GPIB_REN_DEASSERT = 0;
        public const short VI_GPIB_REN_ASSERT = 1;
        public const short VI_GPIB_REN_DEASSERT_GTL = 2;
        public const short VI_GPIB_REN_ASSERT_ADDRESS = 3;
        public const short VI_GPIB_REN_ASSERT_LLO = 4;
        public const short VI_GPIB_REN_ASSERT_ADDRESS_LLO = 5;
        public const short VI_GPIB_REN_ADDRESS_GTL = 6;
        public const short VI_GPIB_ATN_DEASSERT = 0;
        public const short VI_GPIB_ATN_ASSERT = 1;
        public const short VI_GPIB_ATN_DEASSERT_HANDSHAKE = 2;
        public const short VI_GPIB_ATN_ASSERT_IMMEDIATE = 3;
        public const short VI_GPIB_HS488_DISABLED = 0;
        public const short VI_GPIB_HS488_NIMPL = -1;
        public const short VI_GPIB_UNADDRESSED = 0;
        public const short VI_GPIB_TALKER = 1;
        public const short VI_GPIB_LISTENER = 2;
        public const short VI_VXI_CMD16 = 512;
        public const short VI_VXI_CMD16_RESP16 = 514;
        public const short VI_VXI_RESP16 = 2;
        public const short VI_VXI_CMD32 = 1024;
        public const short VI_VXI_CMD32_RESP16 = 1026;
        public const short VI_VXI_CMD32_RESP32 = 1028;
        public const short VI_VXI_RESP32 = 4;
        public const short VI_ASSERT_SIGNAL = -1;
        public const short VI_ASSERT_USE_ASSIGNED = 0;
        public const short VI_ASSERT_IRQ1 = 1;
        public const short VI_ASSERT_IRQ2 = 2;
        public const short VI_ASSERT_IRQ3 = 3;
        public const short VI_ASSERT_IRQ4 = 4;
        public const short VI_ASSERT_IRQ5 = 5;
        public const short VI_ASSERT_IRQ6 = 6;
        public const short VI_ASSERT_IRQ7 = 7;
        public const short VI_UTIL_ASSERT_SYSRESET = 1;
        public const short VI_UTIL_ASSERT_SYSFAIL = 2;
        public const short VI_UTIL_DEASSERT_SYSFAIL = 3;
        public const short VI_VXI_CLASS_MEMORY = 0;
        public const short VI_VXI_CLASS_EXTENDED = 1;
        public const short VI_VXI_CLASS_MESSAGE = 2;
        public const short VI_VXI_CLASS_REGISTER = 3;
        public const short VI_VXI_CLASS_OTHER = 4;
        #endregion

        #region - Backward Compatibility Macros -----------------------------------------
        public const int VI_ERROR_INV_SESSION = -1073807346;
        public const int VI_INFINITE = -1;
        public const short VI_NORMAL = 1;
        public const short VI_FDC = 2;
        public const short VI_HS488 = 3;
        public const short VI_ASRL488 = 4;
        public const short VI_ASRL_IN_BUF = 16;
        public const short VI_ASRL_OUT_BUF = 32;
        public const short VI_ASRL_IN_BUF_DISCARD = 64;
        public const short VI_ASRL_OUT_BUF_DISCARD = 128;
        #endregion

        #endregion

        private const string VisaDllName = "RsVisa32.dll"; // Windows Name

        // override the dll name, dependent on the OS.
        static NativeMethods() => NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), (libraryName, assembly, dllImportSearchPath) =>
        {
            if (libraryName == VisaDllName)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    return NativeLibrary.Load("RsVisa32.dll", assembly, dllImportSearchPath);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return NativeLibrary.Load("librsvisa.so", assembly, dllImportSearchPath);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return NativeLibrary.Load("librsvisa.dylib", assembly, dllImportSearchPath);
                }
            }

            return NativeLibrary.Load(libraryName, assembly, dllImportSearchPath);
        });

        public delegate ViStatus ViEventHandler(int vi, ViEventType inEventType, int inContext, int inUserHandle);

        #region - Resource Template Functions and Operations ----------------------------
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viOpenDefaultRM(out int sesn);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGetDefaultRM(out int sesn);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viFindRsrc(int sesn, string expr, out int vi, out int retCount, StringBuilder desc);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viFindNext(int vi, StringBuilder desc);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viParseRsrc(int sesn, string desc, out short intfType, out short intfNum);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viParseRsrcEx(int sesn, string desc, out short intfType, out short intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viOpen(int sesn, string viDesc, int mode, int timeout, out int vi);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viClose(int vi);

        #region viGetAttribute Overloads
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGetAttribute(int vi, ViAttr attrName, out byte attrValue);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGetAttribute(int vi, ViAttr attrName, out short attrValue);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGetAttribute(int vi, ViAttr attrName, out int attrValue);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGetAttribute(int vi, ViAttr attrName, StringBuilder attrValue);
        #endregion

        #region viSetAttribute Overloads
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viSetAttribute(int vi, ViAttr attrName, byte attrValue);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viSetAttribute(int vi, ViAttr attrName, short attrValue);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viSetAttribute(int vi, ViAttr attrName, int attrValue);
        #endregion

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viStatusDesc(int vi, ViStatus status, StringBuilder desc);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viTerminate(int vi, short degree, int jobId);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viLock(int vi, int lockType, int timeout, string requestedKey, StringBuilder accessKey);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viUnlock(int vi);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viEnableEvent(int vi, ViEventType eventType, short mechanism, int context);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viDisableEvent(int vi, ViEventType eventType, short mechanism);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viDiscardEvents(int vi, ViEventType eventType, short mechanism);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWaitOnEvent(int vi, ViEventType inEventType, int timeout, out ViEventType outEventType, out int outEventContext);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viInstallHandler(int vi, ViEventType inEventType, ViEventHandler inHandler, int inUserHandle);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viUninstallHandler(int vi, ViEventType inEventType, ViEventHandler inHandler, int inUserHandle);
        #endregion

        #region - Basic I/O Operations --------------------------------------------------
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viRead(int vi, byte[] buffer, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viReadAsync(int vi, byte[] buffer, int count, out int jobId);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viReadToFile(int vi, string filename, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWrite(int vi, byte[] buffer, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWriteAsync(int vi, byte[] buffer, int count, out int jobId);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWriteFromFile(int vi, string filename, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viAssertTrigger(int vi, short protocol);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viReadSTB(int vi, out short status);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viClear(int vi);
        #endregion

        #region - Basic I/O Operations with convenient types ----------------------------
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viRead(int vi, StringBuilder buffer, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWrite(int vi, string buffer, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viReadAsync(int vi, StringBuilder buffer, int count, out int jobId);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viWriteAsync(int vi, string buffer, int count, out int jobId);
        #endregion

        #region - Shared Memory Operations ----------------------------------------------

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viMemAlloc(int vi, int memSize, out int offset);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viMemFree(int vi, int offset);
        #endregion

        #region - Interface Specific Operations -----------------------------------------
        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGpibControlREN(int vi, short mode);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGpibControlATN(int vi, short mode);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGpibSendIFC(int vi);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGpibCommand(int vi, string buffer, int count, out int retCount);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viGpibPassControl(int vi, short primAddr, short secAddr);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viVxiCommandQuery(int vi, short mode, int devCmd, out int devResponse);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viAssertUtilSignal(int vi, short line);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viAssertIntrSignal(int vi, short mode, int statusID);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viMapTrigger(int vi, short trigSrc, short trigDest, short mode);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viUnmapTrigger(int vi, short trigSrc, short trigDest);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viUsbControlOut(int vi, short bmRequestType, short bRequest, short wValue, short wIndex, short wLength, byte[] buf);

        [DllImport(VisaDllName, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern ViStatus viUsbControlIn(int vi, short bmRequestType, short bRequest, short wValue, short wIndex, short wLength, byte[] buf, out short retCnt);
        #endregion

    }
}
