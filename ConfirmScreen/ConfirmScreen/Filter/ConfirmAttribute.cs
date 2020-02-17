using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.Filter
{
    /// <summary>
    /// 確認画面描画用のアクションフィルター。
    /// リクエストしたアクションメソッドの前後で呼び出される。
    /// [使用方法]
    ///     ・確認画面用のViewファイルの名前は、アクションメソッド名+Confirmとすること
    ///     ・確認画面に配置するinputタグは、自作したタグヘルパー(TagHelpers/ConfirmTagHelper.csなど)を使用すること
    /// </summary>
    public class ConfirmAttribute : ActionFilterAttribute
    {
        private const string SubmitButtonKey = "__SubmitButton";　　　　//　←自作したタグヘルパーのname属性と同じであること。
        private const string ConfirmButtonKey = "__ConfirmButton";      //　←自作したタグヘルパーのname属性と同じであること。
        private const string BackButtonKey = "__BackButton";            //　←自作したタグヘルパーのname属性と同じであること。

        private const string ViewSuffix = "Confirm";

        /// <summary>
        /// アクションメソッド実行前処理
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var form = context.HttpContext.Request.Form;

            var factory = context.HttpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;

            // ※Post先アクションメソッド(EditとかCreate)の第一引数と、確認画面で定義する「@model」は同じ型である必要があります。※
            var parameter = context.ActionArguments.FirstOrDefault();

            // 登録ボタンの場合
            if (form.Any(f => f.Key == SubmitButtonKey))
            {
                return;
            }

            // 確認ボタンの場合
            var viewName = (string)context.RouteData.Values["Action"];
            if (form.Any(f => f.Key == ConfirmButtonKey))
            {
                // モデルの検証でエラーが発生しているか調べる
                if (!context.ModelState.IsValid)
                {

                    // エラーが発生しているので何もしない
                    return;
                }

                // 確認画面を表示するためにビュー名を変更
                viewName += ViewSuffix;
            }


            var controller = context.Controller as Controller;

            // ビューを表示する（戻るボタンを押した場合は入力内容そのままで戻る）
            context.Result = new ViewResult
            {
                ViewName = viewName,

                // Viewにモデルの内容を渡すために必要。ViewのModelに値が入る。
                ViewData = new ViewDataDictionary(controller.ViewData) { Model = parameter.Value }

            };

        }

        /// <summary>
        /// アクションメソッド実行後処理
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }

}
