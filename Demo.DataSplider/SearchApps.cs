using Demo.DataSplider.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataSplider
{
    public class SearchApps
    {
        /// <summary>
        /// 豌豆荚 搜索 某些应用程序及公司
        /// 1.httpclient 请求接口获取json，获取某个分类下面的应用列表，手动输入URL。
        /// 2.遍历获取每个应用的详情信息。
        /// 3.找到查看更多按钮，递归。
        /// </summary>
        public void WandoujiaEntry()
        {
            string url = "https://www.wandoujia.com/wdjweb/api/category/more?catId=5017&subCatId=0&page=1";

            //httpget json data
            string content = GetJsonDataByAPI(url);
            //xml parse app list.
            List<AppInfo> appList = WandoujiaAppList(content);
            //get app detail info.
            GetAppDetailInfo(appList);
        }

        public string GetJsonDataByAPI(string url)
        {
            string allContents = "";
            WandoujiaList wandoujiaList = HttpClientHelp.GetResponse<WandoujiaList>(url);
            if (wandoujiaList.data != null && wandoujiaList.data.content != null)
            {
                allContents += wandoujiaList.data.content;
            }
            return allContents;
            //todo: 加载更多more。
        }

        
        public List<AppInfo> WandoujiaAppList(string content)
        { 
            var rule = new SpliderRule()
            { 
                //ContentXPath = "//ul[@id='j-tag-list']",//这是从网页上找。
                ContentXPath = @"/",//这是从网页上找。
                EachXPath = "li[@class='card']",
                Url = "", //豌豆荚 某个分类下的应用列表。url应该作为一个参数输入。
                RuleFields = new List<RuleField>() {
                        new RuleField(){ DisplayName="Id",XPath="a[@class='detail-check-btn']",Attribute="data-app-id", IsFirstInnerText=false },
                         new RuleField(){ DisplayName="Name",XPath="div[@class='app-desc']/h2/a", IsFirstInnerText=true },
                         new RuleField(){ DisplayName="URL",XPath="a[@class='detail-check-btn']",Attribute="href", IsFirstInnerText=false },
                         //new RuleField(){ DisplayName="图标",XPath="p[@class='tem']/span",Attribute="", IsFirstInnerText=true },
                         new RuleField(){ DisplayName="InstallCount",XPath="div[@class='app-desc']/div[@class='meta']/span[@class='install-count']",Attribute="", IsFirstInnerText=true }, 
                           }
            };
            var splider = new AppsSplider();
            List<SpliderContent> list = splider.GetByRule(rule, content);
            //打印出来
            List<AppInfo> appList = new List<AppInfo>();
            //AppList appList = new AppList();  
            foreach (var item in list)
            { 
                AppInfo appInfo = new AppInfo();
                var msg = string.Empty;
                int id = 0;
                item.Fields.ForEach(M =>
                {
                    switch (M.DisplayName)
                    {
                        case "Id":
                            appInfo.Id =  M.Value;
                            break;
                        case "Name":
                            appInfo.Name = M.Value;
                            break;
                        case "URL":
                            appInfo.URL= M.Value;
                            break;
                        default:
                            break;
                    }
                    appList.Add(appInfo);
                    msg += $"{M.DisplayName}:{M.Value}     ";
                });
                Console.WriteLine(msg);
            }
            return appList;
        }

        public void GetAppDetailInfo(List<AppInfo> appList)
        {
            if (appList == null || appList.Count == 0)
            {
                return;
            }

            foreach (AppInfo item in appList)
            {
                WandoujiaAppDetail(item);
            } 
        }

        //从详情页里面读取公司名称等信息。
        public AppInfo WandoujiaAppDetail(AppInfo info)
        {
            var rule = new SpliderRule()
            {
                ContentXPath = "//dl[@class='infos-list']",
                EachXPath = "",
                Url = info.URL,
                RuleFields = new List<RuleField>() {
                    new RuleField(){ DisplayName="Company",XPath="//span[@class='dev-sites']",Attribute="", IsFirstInnerText=false},
                        //new RuleField(){ DisplayName="Name",XPath="div[@class='app-desc']/h2/a", IsFirstInnerText=true },
                        //new RuleField(){ DisplayName="URL",XPath="a[@class='detail-check-btn']",Attribute="href", IsFirstInnerText=false },
                        }
            };
            var splider = new AppsSplider();
            List<SpliderContent> list = splider.GetByRule(rule);
            
            AppInfo appInfo = new AppInfo();
            foreach (var item in list)
            {
               
                var msg = string.Empty;
                int id = 0;
                item.Fields.ForEach(M =>
                {
                    switch (M.DisplayName)
                    {
                        case "Company":
                            appInfo.Company = M.Value;
                            break;
                        case "Description":
                            appInfo.Description = M.Value;
                            break;
                        case "URL":
                            appInfo.URL = M.Value;
                            break;
                        default:
                            break;
                    } 
                    msg += $"{M.DisplayName}:{M.Value}     ";
                });
                Console.WriteLine(msg);
            }
            return appInfo;
        }


        public AppInfo WandoujiaAppDetailUnitTest()
        {
            var rule = new SpliderRule()
            {
                ContentXPath = "//dl[@class='infos-list']", 
                EachXPath = "",
                Url = "",
                RuleFields = new List<RuleField>() {
                    new RuleField(){ DisplayName="Company",XPath="//span[@class='dev-sites']",Attribute="", IsFirstInnerText=false},
                        //new RuleField(){ DisplayName="Name",XPath="div[@class='app-desc']/h2/a", IsFirstInnerText=true },
                        //new RuleField(){ DisplayName="URL",XPath="a[@class='detail-check-btn']",Attribute="href", IsFirstInnerText=false },
                        }
            };
            var splider = new AppsSplider();
            string fileName = @"E:\DevProjects\html-agility-pack\CsharpFanDemo-fork\CsharpFanDemo\Demo.DataSplider\testfiles\detailpage.html";
            List<SpliderContent> list = splider.GetByRuleFromFile(rule, fileName);

            AppInfo appInfo = new AppInfo();
            foreach (var item in list)
            {

                var msg = string.Empty;
                int id = 0;
                item.Fields.ForEach(M =>
                {
                    switch (M.DisplayName)
                    {
                        case "Company":
                            appInfo.Company = M.Value;
                            break;
                        case "Description":
                            appInfo.Description = M.Value;
                            break;
                        case "URL":
                            appInfo.URL = M.Value;
                            break;
                        default:
                            break;
                    }
                    msg += $"{M.DisplayName}:{M.Value}     ";
                });
                Console.WriteLine(msg);
            }
            return appInfo;
        }
    }
} 