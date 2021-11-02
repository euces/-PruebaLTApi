using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Common.Helper
{
    public static class EnumHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetDescription(this Enum GenericEnum)
        {

            Type genericEnumType = GenericEnum.GetType();
            System.Reflection.MemberInfo[] memberInfo =
                        genericEnumType.GetMember(GenericEnum.ToString());

            if ((memberInfo != null && memberInfo.Length > 0))
            {

                dynamic _Attribs = memberInfo[0].GetCustomAttributes
                      (typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs[0]).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}
