using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.TagHelpers
{
    /// <summary>
    /// 確認用ボタン
    /// </summary>
    public class ConfirmTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "input";
            output.Attributes.Add("type","submit");
            output.Attributes.Add("name", "__ConfirmButton"); //←ここが重要
        }
    }
}
