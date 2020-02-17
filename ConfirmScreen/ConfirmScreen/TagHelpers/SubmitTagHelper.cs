using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.TagHelpers
{
    /// <summary>
    /// 登録用ボタン
    /// </summary>
    public class SubmitTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "input";
            output.Attributes.Add("type","submit");
            output.Attributes.Add("name", "__SubmitButton"); //←ここが重要
        }
    }
}
