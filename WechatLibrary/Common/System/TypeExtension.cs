﻿
namespace System
{
    /// <summary>
    /// 类型扩展类。
    /// </summary>
    public static partial class TypeExtension
    {
        /// <summary>
        /// 指示当前类型是否实现指定的接口类型。
        /// </summary>
        /// <param name="type">当前类型。</param>
        /// <param name="interfaceType">接口类型。</param>
        /// <returns>指示是否实现了接口。</returns>
        /// <exception cref="System.ArgumentException"><c>interfaceType</c> 不是接口类型。</exception>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 或 <c>interface</c> 为 null。</exception>
        public static bool IsImplementInterface(this Type type, Type interfaceType)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type 不能为空。");
            }
            if (interfaceType == null)
            {
                throw new ArgumentNullException("interfaceType 不能为空。");
            }
            if (interfaceType.IsInterface == false)
            {
                throw new ArgumentException("interfaceType 不是接口类型。");
            }
            return interfaceType.IsAssignableFrom(type);
        }
    }
}