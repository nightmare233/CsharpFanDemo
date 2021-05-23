using Demo.DataSplider.DemoPick;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Demo.DataSplider.Models
{
    public class AppsSplider
    {
        /// <summary>
        /// 根据Rule
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public List<SpliderContent> GetByRule(SpliderRule rule, string content)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content); 

            var contentnode = htmlDoc.DocumentNode.SelectSingleNode(rule.ContentXPath);

            var list = new List<SpliderContent>();
        
            if (!string.IsNullOrWhiteSpace(rule.EachXPath))
            {
                var itemsNodes = contentnode.SelectNodes(rule.EachXPath);
                foreach (var item in itemsNodes)
                {
                    var fields = GetFields(item, rule);

                    list.Add(new SpliderContent()
                    {
                        Fields = fields,
                        SpliderRuleId = rule.Id
                    });
                } 
            }
            return list;
        }

        public List<SpliderContent> GetByRule(SpliderRule rule)
        { 
            HtmlWeb web = new HtmlWeb();
            //1.支持从web加载html
            var htmlDoc = web.Load(rule.Url);
            var contentnode = htmlDoc.DocumentNode.SelectSingleNode(rule.ContentXPath);

            var list = new List<SpliderContent>();
            //详情页
            var cfields = GetFields(contentnode, rule);
            var sc = new SpliderContent()
            {
                Fields = cfields,
                SpliderRuleId = rule.Id
            };
            list.Add(sc);
            return list;
        }

        public List<SpliderContent> GetByRuleFromFile(SpliderRule rule, string filename)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(filename);
            var contentnode = htmlDoc.DocumentNode.SelectSingleNode(rule.ContentXPath);

            var list = new List<SpliderContent>();
            //详情页
            var cfields = GetFields(contentnode, rule);
            var sc = new SpliderContent()
            {
                Fields = cfields,
                SpliderRuleId = rule.Id
            };
            list.Add(sc);
            return list;
        }


        public List<Field> GetFields(HtmlNode item, SpliderRule rule)
        {
            List<Field> fields = new List<Field>();
            if (item == null)
            {
                Console.WriteLine("item is null...");
                return fields; 
            }
           
            foreach (var rulefield in rule.RuleFields)
            {
                var field = new Field() { DisplayName = rulefield.DisplayName, FieldName = "" };

                var fieldnode = item.SelectSingleNode(rulefield.XPath);
                if (fieldnode != null)
                {

                    field.InnerHtml = fieldnode.InnerHtml;
                    field.InnerText = fieldnode.InnerText;
                    field.AfterRegexHtml = !string.IsNullOrWhiteSpace(rulefield.InnerHtmlRegex) ? Regex.Replace(fieldnode.InnerHtml, rulefield.InnerHtmlRegex, "") : fieldnode.InnerHtml;
                    field.AfterRegexText = !string.IsNullOrWhiteSpace(rulefield.InnerTextRegex) ? Regex.Replace(fieldnode.InnerText, rulefield.InnerTextRegex, "") : fieldnode.InnerText;
                     
                    if (!string.IsNullOrWhiteSpace(rulefield.Attribute))
                    {
                        field.Value = fieldnode.Attributes[rulefield.Attribute].Value;
                    }
                    else
                    {
                        field.Value = rulefield.IsFirstInnerText ? field.AfterRegexText : field.AfterRegexHtml;
                    }
                }
                fields.Add(field);
            }
            return fields;
        }
    }
}
