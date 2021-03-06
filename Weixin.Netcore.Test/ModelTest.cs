﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Weixin.Netcore.Model.WeixinMenu;
using Weixin.Netcore.Model.WeixinMenu.Button;

namespace Weixin.Netcore.Test
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void MenuModelTest()
        {
            IMenu menu = new Menu();

            menu.button.Add(new SingleClickButton("今日歌曲")
            {
                key = "V1001_TODAY_MUSIC"
            });
            menu.button.Add(new SubButton("菜单")
            {
                sub_button = new List<SingleButton>()
                {
                    new SingleViewButton("搜索")
                    {
                        url = "www.soso.com"
                    },
                    new SingleProgramButton("wxa")
                    {
                        url = "http://mp.weixin.com",
                        appid = "wx286b93c14bbf93aa",
                        pagepath = "pages/lunar/index"
                    },
                    new SingleClickButton("赞一下我们")
                    {
                        key = "V1001_GOOD"
                    }
                }
            });

            Console.WriteLine(menu.ToJson());
        }
    }
}
