// <copyright file="IVisa.cs" company="Rohde &amp; Schwarz GmbH &amp; Co. KG">
// Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System.Text;
using ViAttr = System.Int32;
using ViSession = System.Int32;
using ViStatus = System.Int32;

#pragma warning disable SA1121, SA1124, CS1591 // Use built-in type alias,  Do not use regions, Missing XML comment for publicly visible type or member

namespace RohdeSchwarz.Iot.Middleware.Model
{
    #region - Constants -------------------------------------------------------------
    #region - Attributes ------------------------------------------------------------

#pragma warning disable SA1602 // Enumeration items should be documented
    /// <summary>
    /// Identifiers for the visa attributes.
    /// See VISA documentation for more informations.
    /// </summary>
    public enum ViAttributes
    {
        VI_ATTR_RSRC_CLASS = -1073807359,
        VI_ATTR_RSRC_NAME = -1073807358,
        VI_ATTR_RSRC_IMPL_VERSION = 1073676291,
        VI_ATTR_RSRC_LOCK_STATE = 1073676292,
        VI_ATTR_MAX_QUEUE_LENGTH = 1073676293,
        VI_ATTR_USER_DATA = 1073676295,
        VI_ATTR_FDC_CHNL = 1073676301,
        VI_ATTR_FDC_MODE = 1073676303,
        VI_ATTR_FDC_GEN_SIGNAL_EN = 1073676305,
        VI_ATTR_FDC_USE_PAIR = 1073676307,
        VI_ATTR_SEND_END_EN = 1073676310,
        VI_ATTR_TERMCHAR = 1073676312,
        VI_ATTR_TMO_VALUE = 1073676314,
        VI_ATTR_GPIB_READDR_EN = 1073676315,
        VI_ATTR_IO_PROT = 1073676316,
        VI_ATTR_DMA_ALLOW_EN = 1073676318,
        VI_ATTR_ASRL_BAUD = 1073676321,
        VI_ATTR_ASRL_DATA_BITS = 1073676322,
        VI_ATTR_ASRL_PARITY = 1073676323,
        VI_ATTR_ASRL_STOP_BITS = 1073676324,
        VI_ATTR_ASRL_FLOW_CNTRL = 1073676325,
        VI_ATTR_RD_BUF_OPER_MODE = 1073676330,
        VI_ATTR_RD_BUF_SIZE = 1073676331,
        VI_ATTR_WR_BUF_OPER_MODE = 1073676333,
        VI_ATTR_WR_BUF_SIZE = 1073676334,
        VI_ATTR_SUPPRESS_END_EN = 1073676342,
        VI_ATTR_TERMCHAR_EN = 1073676344,
        VI_ATTR_DEST_ACCESS_PRIV = 1073676345,
        VI_ATTR_DEST_BYTE_ORDER = 1073676346,
        VI_ATTR_SRC_ACCESS_PRIV = 1073676348,
        VI_ATTR_SRC_BYTE_ORDER = 1073676349,
        VI_ATTR_SRC_INCREMENT = 1073676352,
        VI_ATTR_DEST_INCREMENT = 1073676353,
        VI_ATTR_WIN_ACCESS_PRIV = 1073676357,
        VI_ATTR_WIN_BYTE_ORDER = 1073676359,
        VI_ATTR_GPIB_ATN_STATE = 1073676375,
        VI_ATTR_GPIB_ADDR_STATE = 1073676380,
        VI_ATTR_GPIB_CIC_STATE = 1073676382,
        VI_ATTR_GPIB_NDAC_STATE = 1073676386,
        VI_ATTR_GPIB_SRQ_STATE = 1073676391,
        VI_ATTR_GPIB_SYS_CNTRL_STATE = 1073676392,
        VI_ATTR_GPIB_HS488_CBL_LEN = 1073676393,
        VI_ATTR_CMDR_LA = 1073676395,
        VI_ATTR_VXI_DEV_CLASS = 1073676396,
        VI_ATTR_MAINFRAME_LA = 1073676400,
        VI_ATTR_MANF_NAME = -1073807246,
        VI_ATTR_MODEL_NAME = -1073807241,
        VI_ATTR_VXI_VME_INTR_STATUS = 1073676427,
        VI_ATTR_VXI_TRIG_STATUS = 1073676429,
        VI_ATTR_VXI_VME_SYSFAIL_STATE = 1073676436,
        VI_ATTR_WIN_BASE_ADDR = 1073676440,
        VI_ATTR_WIN_SIZE = 1073676442,
        VI_ATTR_ASRL_AVAIL_NUM = 1073676460,
        VI_ATTR_MEM_BASE = 1073676461,
        VI_ATTR_ASRL_CTS_STATE = 1073676462,
        VI_ATTR_ASRL_DCD_STATE = 1073676463,
        VI_ATTR_ASRL_DSR_STATE = 1073676465,
        VI_ATTR_ASRL_DTR_STATE = 1073676466,
        VI_ATTR_ASRL_END_IN = 1073676467,
        VI_ATTR_ASRL_END_OUT = 1073676468,
        VI_ATTR_ASRL_REPLACE_CHAR = 1073676478,
        VI_ATTR_ASRL_RI_STATE = 1073676479,
        VI_ATTR_ASRL_RTS_STATE = 1073676480,
        VI_ATTR_ASRL_XON_CHAR = 1073676481,
        VI_ATTR_ASRL_XOFF_CHAR = 1073676482,
        VI_ATTR_WIN_ACCESS = 1073676483,
        VI_ATTR_RM_SESSION = 1073676484,
        VI_ATTR_VXI_LA = 1073676501,
        VI_ATTR_MANF_ID = 1073676505,
        VI_ATTR_MEM_SIZE = 1073676509,
        VI_ATTR_MEM_SPACE = 1073676510,
        VI_ATTR_MODEL_CODE = 1073676511,
        VI_ATTR_SLOT = 1073676520,
        VI_ATTR_INTF_INST_NAME = -1073807127,
        VI_ATTR_IMMEDIATE_SERV = 1073676544,
        VI_ATTR_INTF_PARENT_NUM = 1073676545,
        VI_ATTR_RSRC_SPEC_VERSION = 1073676656,
        VI_ATTR_INTF_TYPE = 1073676657,
        VI_ATTR_GPIB_PRIMARY_ADDR = 1073676658,
        VI_ATTR_GPIB_SECONDARY_ADDR = 1073676659,
        VI_ATTR_RSRC_MANF_NAME = -1073806988,
        VI_ATTR_RSRC_MANF_ID = 1073676661,
        VI_ATTR_INTF_NUM = 1073676662,
        VI_ATTR_TRIG_ID = 1073676663,
        VI_ATTR_GPIB_REN_STATE = 1073676673,
        VI_ATTR_GPIB_UNADDR_EN = 1073676676,
        VI_ATTR_DEV_STATUS_BYTE = 1073676681,
        VI_ATTR_FILE_APPEND_EN = 1073676690,
        VI_ATTR_VXI_TRIG_SUPPORT = 1073676692,
        VI_ATTR_TCPIP_ADDR = -1073806955,
        VI_ATTR_TCPIP_HOSTNAME = -1073806954,
        VI_ATTR_TCPIP_PORT = 1073676695,
        VI_ATTR_TCPIP_DEVICE_NAME = -1073806951,
        VI_ATTR_TCPIP_NODELAY = 1073676698,
        VI_ATTR_TCPIP_KEEPALIVE = 1073676699,
        VI_ATTR_4882_COMPLIANT = 1073676703,
        VI_ATTR_USB_SERIAL_NUM = -1073806944,
        VI_ATTR_USB_INTFC_NUM = 1073676705,
        VI_ATTR_USB_PROTOCOL = 1073676711,
        VI_ATTR_USB_MAX_INTR_SIZE = 1073676719,
        VI_ATTR_JOB_ID = 1073692678,
        VI_ATTR_EVENT_TYPE = 1073692688,
        VI_ATTR_SIGP_STATUS_ID = 1073692689,
        VI_ATTR_RECV_TRIG_ID = 1073692690,
        VI_ATTR_INTR_STATUS_ID = 1073692707,
        VI_ATTR_STATUS = 1073692709,
        VI_ATTR_RET_COUNT = 1073692710,
        VI_ATTR_BUFFER = 1073692711,
        VI_ATTR_RECV_INTR_LEVEL = 1073692737,
        VI_ATTR_OPER_NAME = -1073790910,
        VI_ATTR_GPIB_RECV_CIC_STATE = 1073693075,
        VI_ATTR_RECV_TCPIP_ADDR = -1073790568,
        VI_ATTR_USB_RECV_INTR_SIZE = 1073693104,
        VI_ATTR_USB_RECV_INTR_DATA = -1073790543,

        // R&S specific attributes to find resources
        VI_RS_ATTR_TCPIP_FIND_RSRC_TMO = 0x0FAF0001,
        VI_RS_ATTR_TCPIP_FIND_RSRC_MODE = 0x0FAF0002,
    }

    /// <summary>
    /// Identifiers for the rsvisa attributes.
    /// See VISA documentation for more informations.
    /// </summary>
    public enum RsAttributes
    {
        VI_RS_FIND_MODE_NONE = 0x00,
        VI_RS_FIND_MODE_CONFIG = 0x01,
        VI_RS_FIND_MODE_VXI11 = 0x02,
        VI_RS_FIND_MODE_MDNS = 0x04,
    }

    #endregion //Attributes

    #region - Event Types -----------------------------------------------------------

    /// <summary>
    /// Identifiers for the visa event types.
    /// See VISA documentation for more informations.
    /// </summary>
    public enum ViEventType
    {
        VI_EVENT_IO_COMPLETION = 1073684489,
        VI_EVENT_TRIG = -1073799158,
        VI_EVENT_SERVICE_REQ = 1073684491,
        VI_EVENT_CLEAR = 1073684493,
        VI_EVENT_EXCEPTION = -1073799154,
        VI_EVENT_GPIB_CIC = 1073684498,
        VI_EVENT_GPIB_TALK = 1073684499,
        VI_EVENT_GPIB_LISTEN = 1073684500,
        VI_EVENT_VXI_VME_SYSFAIL = 1073684509,
        VI_EVENT_VXI_VME_SYSRESET = 1073684510,
        VI_EVENT_VXI_SIGP = 1073684512,
        VI_EVENT_VXI_VME_INTR = -1073799135,
        VI_EVENT_TCPIP_CONNECT = 1073684534,
        VI_EVENT_USB_INTR = 1073684535,
        VI_ALL_ENABLED_EVENTS = 1073709055,
    }
#pragma warning restore SA1602 // Enumeration items should be documented

    #endregion//Event Types

    #region - Completion and Error Codes --------------------------------------------
    /*
    public enum ViStatus
    {
        VI_SUCCESS = 0,
        VI_SUCCESS_EVENT_EN = 1073676290,
        VI_SUCCESS_EVENT_DIS = 1073676291,
        VI_SUCCESS_QUEUE_EMPTY = 1073676292,
        VI_SUCCESS_TERM_CHAR = 1073676293,
        VI_SUCCESS_MAX_CNT = 1073676294,
        VI_SUCCESS_DEV_NPRESENT = 1073676413,
        VI_SUCCESS_TRIG_MAPPED = 1073676414,
        VI_SUCCESS_QUEUE_NEMPTY = 1073676416,
        VI_SUCCESS_NCHAIN = 1073676440,
        VI_SUCCESS_NESTED_SHARED = 1073676441,
        VI_SUCCESS_NESTED_EXCLUSIVE = 1073676442,
        VI_SUCCESS_SYNC = 1073676443,
        VI_WARN_QUEUE_OVERFLOW = 1073676300,
        VI_WARN_CONFIG_NLOADED = 1073676407,
        VI_WARN_NULL_OBJECT = 1073676418,
        VI_WARN_NSUP_ATTR_STATE = 1073676420,
        VI_WARN_UNKNOWN_STATUS = 1073676421,
        VI_WARN_NSUP_BUF = 1073676424,
        VI_WARN_EXT_FUNC_NIMPL = 1073676457,
        VI_ERROR_SYSTEM_ERROR = -1073807360,
        VI_ERROR_INV_OBJECT = -1073807346,
        VI_ERROR_RSRC_LOCKED = -1073807345,
        VI_ERROR_INV_EXPR = -1073807344,
        VI_ERROR_RSRC_NFOUND = -1073807343,
        VI_ERROR_INV_RSRC_NAME = -1073807342,
        VI_ERROR_INV_ACC_MODE = -1073807341,
        VI_ERROR_TMO = -1073807339,
        VI_ERROR_CLOSING_FAILED = -1073807338,
        VI_ERROR_INV_DEGREE = -1073807333,
        VI_ERROR_INV_JOB_ID = -1073807332,
        VI_ERROR_NSUP_ATTR = -1073807331,
        VI_ERROR_NSUP_ATTR_STATE = -1073807330,
        VI_ERROR_ATTR_READONLY = -1073807329,
        VI_ERROR_INV_LOCK_TYPE = -1073807328,
        VI_ERROR_INV_ACCESS_KEY = -1073807327,
        VI_ERROR_INV_EVENT = -1073807322,
        VI_ERROR_INV_MECH = -1073807321,
        VI_ERROR_HNDLR_NINSTALLED = -1073807320,
        VI_ERROR_INV_HNDLR_REF = -1073807319,
        VI_ERROR_INV_CONTEXT = -1073807318,
        VI_ERROR_NENABLED = -1073807313,
        VI_ERROR_ABORT = -1073807312,
        VI_ERROR_RAW_WR_PROT_VIOL = -1073807308,
        VI_ERROR_RAW_RD_PROT_VIOL = -1073807307,
        VI_ERROR_OUTP_PROT_VIOL = -1073807306,
        VI_ERROR_INP_PROT_VIOL = -1073807305,
        VI_ERROR_BERR = -1073807304,
        VI_ERROR_IN_PROGRESS = -1073807303,
        VI_ERROR_INV_SETUP = -1073807302,
        VI_ERROR_QUEUE_ERROR = -1073807301,
        VI_ERROR_ALLOC = -1073807300,
        VI_ERROR_INV_MASK = -1073807299,
        VI_ERROR_IO = -1073807298,
        VI_ERROR_INV_FMT = -1073807297,
        VI_ERROR_NSUP_FMT = -1073807295,
        VI_ERROR_LINE_IN_USE = -1073807294,
        VI_ERROR_NSUP_MODE = -1073807290,
        VI_ERROR_SRQ_NOCCURRED = -1073807286,
        VI_ERROR_INV_SPACE = -1073807282,
        VI_ERROR_INV_OFFSET = -1073807279,
        VI_ERROR_INV_WIDTH = -1073807278,
        VI_ERROR_NSUP_OFFSET = -1073807276,
        VI_ERROR_NSUP_VAR_WIDTH = -1073807275,
        VI_ERROR_WINDOW_NMAPPED = -1073807273,
        VI_ERROR_RESP_PENDING = -1073807271,
        VI_ERROR_NLISTENERS = -1073807265,
        VI_ERROR_NCIC = -1073807264,
        VI_ERROR_NSYS_CNTLR = -1073807263,
        VI_ERROR_NSUP_OPER = -1073807257,
        VI_ERROR_INTR_PENDING = -1073807256,
        VI_ERROR_ASRL_PARITY = -1073807254,
        VI_ERROR_ASRL_FRAMING = -1073807253,
        VI_ERROR_ASRL_OVERRUN = -1073807252,
        VI_ERROR_TRIG_NMAPPED = -1073807250,
        VI_ERROR_NSUP_ALIGN_OFFSET = -1073807248,
        VI_ERROR_USER_BUF = -1073807247,
        VI_ERROR_RSRC_BUSY = -1073807246,
        VI_ERROR_NSUP_WIDTH = -1073807242,
        VI_ERROR_INV_PARAMETER = -1073807240,
        VI_ERROR_INV_PROT = -1073807239,
        VI_ERROR_INV_SIZE = -1073807237,
        VI_ERROR_WINDOW_MAPPED = -1073807232,
        VI_ERROR_NIMPL_OPER = -1073807231,
        VI_ERROR_INV_LENGTH = -1073807229,
        VI_ERROR_INV_MODE = -1073807215,
        VI_ERROR_SESN_NLOCKED = -1073807204,
        VI_ERROR_MEM_NSHARED = -1073807203,
        VI_ERROR_LIBRARY_NFOUND = -1073807202,
        VI_ERROR_NSUP_INTR = -1073807201,
        VI_ERROR_INV_LINE = -1073807200,
        VI_ERROR_FILE_ACCESS = -1073807199,
        VI_ERROR_FILE_IO = -1073807198,
        VI_ERROR_NSUP_LINE = -1073807197,
        VI_ERROR_NSUP_MECH = -1073807196,
        VI_ERROR_INTF_NUM_NCONFIG = -1073807195,
        VI_ERROR_CONN_LOST = -1073807194,
    };
    */
    #endregion //Completion and Error Codes
    #endregion //Constants

    /// <summary>
    /// Abstraction of the VISA interface.
    /// </summary>
    public interface IVisa
    {
        /// <summary>
        /// Return a session to the Default Resource Manager resource.
        /// </summary>
        /// <param name="sesn">Unique logical identifier to a Default Resource Manager session.</param>
        /// <returns>The return status.</returns>
        ViStatus ViOpenDefaultRM(out ViSession sesn);

        /// <summary>
        /// Query a VISA system to locate the resources associated with a specified interface.
        /// </summary>
        /// <param name="sesn">Resource Manager session (should always be the Default Resource Manager for VISA returned from viOpenDefaultRM()).</param>
        /// <param name="expr">This is a regular expression followed by an optional logical expression. The grammar for this expression is given below.</param>
        /// <param name="vi">Returns a handle identifying this search session. This handle will be used as an input in viFindNext().</param>
        /// <param name="retCount">Number of matches.</param>
        /// <param name="desc">Returns a string identifying the location of a device. Strings can then be passed to viOpen() to establish a session to the given device.</param>
        /// <returns>The return status.</returns>
        ViStatus ViFindRsrc(ViSession sesn, string expr, out int vi, out int retCount, StringBuilder desc);

        /// <summary>
        /// Return the next resource found during a previous call to viFindRsrc().
        /// </summary>
        /// <param name="vi">Describes a find list. This parameter must be created by viFindRsrc().</param>
        /// <param name="desc">Returns a string identifying the location of a device. Strings can then be passed to viOpen() to establish a session to the given device.</param>
        /// <returns>The return status.</returns>
        ViStatus ViFindNext(ViSession vi, StringBuilder desc);

        /// <summary>
        /// Parse a resource string to get the interface information.
        /// </summary>
        /// <param name="sesn">Resource Manager session (should always be the Default Resource Manager for VISA returned from viOpenDefaultRM()).</param>
        /// <param name="desc">Unique symbolic name of a resource.</param>
        /// <param name="intfType">Interface type of the given resource string.</param>
        /// <param name="intfNum">Board number of the interface of the given resource string.</param>
        /// <returns>The return status.</returns>
        ViStatus ViParseRsrc(ViSession sesn, string desc, out ushort intfType, out ushort intfNum);

        /// <summary>
        /// Parse a resource string to get extended interface information.
        /// </summary>
        /// <param name="sesn">Resource Manager session (should always be the Default Resource Manager for VISA returned from viOpenDefaultRM()).</param>
        /// <param name="desc">Unique symbolic name of a resource.</param>
        /// <param name="intfType">Interface type of the given resource string.</param>
        /// <param name="intfNum">Board number of the interface of the given resource string.</param>
        /// <param name="rsrcClass">Specifies the resource class (for example, “INSTR”) of the given resource string.</param>
        /// <param name="expandedUnaliasedName">This is the expanded version of the given resource string. The format should be similar to the VISA-defined canonical resource name.</param>
        /// <param name="aliasIfExists">Specifies the user-defined alias for the given resource string.</param>
        /// <returns>The return status.</returns>
        ViStatus ViParseRsrcEx(ViSession sesn, string desc, out ushort intfType, out ushort intfNum, StringBuilder rsrcClass, StringBuilder expandedUnaliasedName, StringBuilder aliasIfExists);

        /// <summary>
        /// Open a session to the specified device.
        /// </summary>
        /// <param name="sesn">Resource Manager session (should always be the Default Resource Manager for VISA returned from viOpenDefaultRM()).</param>
        /// <param name="viDesc">Unique symbolic name of a resource.</param>
        /// <param name="mode">Specifies the modes by which the resource is to be accessed. The value VI_EXCLUSIVE_LOCK is used to acquire
        /// an exclusive lock immediately upon opening a session; if a lock cannot be acquired, the session is closed and an error is returned.
        /// The value VI_LOAD_CONFIG is used to configure attributes to values specified by some external configuration utility;
        /// if this value is not used, the session uses the default values provided by this specification.Multiple access modes
        /// can be used simultaneously by specifying a "bit-wise OR" of the above values.</param>
        /// <param name="timeout">If the accessMode parameter requests a lock, then this parameter specifies the absolute time period (in milliseconds)
        /// that the resource waits to get unlocked before this operation returns an error.</param>
        /// <param name="vi">Unique logical identifier reference to a session.</param>
        /// <returns>The return status.</returns>
        ViStatus ViOpen(ViSession sesn, string viDesc, int mode, int timeout, out int vi);

        /// <summary>
        /// Close the specified session, event, or find list.
        /// </summary>
        /// <param name="vi">Unique logical identifier to a session, event, or find list.</param>
        /// <returns>The return status.</returns>
        ViStatus ViClose(ViSession vi);

        /// <summary>
        /// Retrieve the state of an attribute.
        /// </summary>
        /// <typeparam name="T">Type of the Attribute, must be byte, short, int or StringBuilder.</typeparam>
        /// <param name="vi">Unique logical identifier to a session, event, or find list.</param>
        /// <param name="attrName">Session, event, or find list attribute for which the state query is made.</param>
        /// <param name="attrValue">The state of the queried attribute for a specified resource. The interpretation of the returned value is defined by the individual resource.</param>
        /// <returns>The return status.</returns>
        ViStatus ViGetAttribute<T>(int vi, ViAttr attrName, out T attrValue);

        /// <summary>
        /// Set the state of an attribute.
        /// </summary>
        /// <typeparam name="T">Type of the Attribute, must be byte, short or int.</typeparam>
        /// <param name="vi">Unique logical identifier to a session, event, or find list.</param>
        /// <param name="attrName">Session, event, or find list attribute for which the state is modified.</param>
        /// <param name="attrValue">The state of the attribute to be set for the specified resource. The interpretation of the individual attribute value is defined by the resource.</param>
        /// <returns>The return status.</returns>
        ViStatus ViSetAttribute<T>(int vi, ViAttr attrName, T attrValue);

        /// <summary>
        /// Write data to device synchronously.
        /// </summary>
        /// <param name="vi">Unique logical identifier to a session.</param>
        /// <param name="buffer">Represents the location of a data block to be sent to device.</param>
        /// <param name="count">Specifies number of bytes to be written.</param>
        /// <param name="retCount">Represents the location of an integer that will be set to the number of bytes actually transferred.</param>
        /// <returns>The return status.</returns>
        ViStatus ViWrite(int vi, byte[] buffer, int count, out int retCount);

        /// <summary>
        /// Read data from device synchronously.
        /// </summary>
        /// <param name="vi">Unique logical identifier to a session.</param>
        /// <param name="buffer">Represents the location of a buffer to receive data from device.</param>
        /// <param name="count">Number of bytes to be read.</param>
        /// <param name="retCount">Represents the location of an integer that will be set to the number of bytes actually transferred.</param>
        /// <returns>The return status.</returns>
        ViStatus ViRead(int vi, byte[] buffer, int count, out int retCount);
    }
}
#pragma warning restore SA1121, SA1124, CS1591 // Use built-in type alias, Do not use regions, Missing XML comment for publicly visible type or member
