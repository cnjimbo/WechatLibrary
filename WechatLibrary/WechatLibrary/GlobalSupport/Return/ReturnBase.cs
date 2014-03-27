using Common.Serialization;

namespace WechatLibrary.Return
{
    /// <summary>
    /// 微信返回码基类。
    /// </summary>
    public class ReturnBase
    {
        /// <summary>
        /// 返回的错误码。
        /// </summary>
        [Json(Name = "errcode")]
        public int ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// 返回的错误信息。
        /// </summary>
        [Json(Name = "errmsg")]
        public string ErrorMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 返回的详细错误信息，在ReturnCode中定义。
        /// </summary>
        [Json(Ignore = true)]
        public string ErrorInformation
        {
            get
            {
                return ReturnCode.GetMessage(ErrorCode);
            }
        }

        internal ReturnBase()
        {
        }
    }
}
