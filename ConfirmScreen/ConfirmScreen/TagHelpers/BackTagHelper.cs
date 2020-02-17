using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.TagHelpers
{
    /// <summary>
    /// 戻る用ボタン
    /// </summary>
    public class BackTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "input";
            output.Attributes.Add("type", "submit");
            output.Attributes.Add("name", "__BackButton"); //←ここが重要
        }
    }
}
