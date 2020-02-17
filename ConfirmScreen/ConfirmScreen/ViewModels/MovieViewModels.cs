using ConfirmScreen.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfirmScreen.ViewModels
{
    public class MovieViewModels
    {

    }


    /// <summary>
    /// 追加画面用のビューモデル
    /// </summary>
    public class MoviewIndexViewModel
    {
        public IEnumerable<ConfirmScreen.Models.Movie> Movies { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }



    /// <summary>
    /// 追加画面用のビューモデル
    /// </summary>
    public class MoviewCreateViewModel
    {
        public Movie Movie { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }


    /// <summary>
    /// 編集画面用のビューモデル
    /// </summary>
    public class MoviewEditViewModel
    {
        public Movie Movie { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }


    public class Common
    {
        public static List<SelectListItem> GENRE_LIST = new List<SelectListItem>() {
                new SelectListItem(){Value ="0",Text="コメディー" },
                new SelectListItem(){Value ="1",Text="恋愛" },
                new SelectListItem(){Value ="2",Text="ホラー" },
            };
    }
}
