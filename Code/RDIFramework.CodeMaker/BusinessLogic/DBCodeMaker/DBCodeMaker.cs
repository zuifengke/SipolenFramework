﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 代码生成器
    /// </summary>
    public partial class DBCodeMaker
    {
        private string company = string.Empty;
        private string project = string.Empty;
        private string author = string.Empty;
        private string yearCreated = DateTime.Now.Year.ToString();
        private string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");

        private string className = string.Empty;
        private string postfix = string.Empty;
        private string description = string.Empty;

        /// <summary>
        /// MVCEntity
        /// </summary>
        public bool MVCEntity = false;

        public string primaryKey = "ID"; 
        /// <summary>
        /// 主键字段
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                // 对主键进行规范化
                if (!string.IsNullOrEmpty(primaryKey))
                {   
                    if (primaryKey.Equals("ID"))
                    {
                        primaryKey = "ID"; 
                    }
                }
                return primaryKey;
            }
            set
            {
                primaryKey = value;
            }
        }
        string _tableName = string.Empty;
        /// <summary>
        /// 当前表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { this._tableName = value; }
        }
        string _dbName = string.Empty;
        /// <summary>
        /// 当前数据库名称
        /// </summary>
        public string DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }      

        /// <summary>
        /// 数据库访问接口
        /// </summary>
        private IDbObject dbObject = null;

        private StringBuilder CodeText = new StringBuilder();
        private StringPlus CodeTextFormat = new StringPlus();

        private string ClassEntity
        {
            get
            {
                return this.className.Substring(0, 1).ToLower() + this.className.Substring(1) + "Entity";
            }
        }

        public DBCodeMaker(IDbObject dbAccess,string databaseName,string tabName)
        {
            this.dbObject = dbAccess;
            this.DBName = databaseName;
            this.TableName = tabName;
        }

        public DBCodeMaker(IDbObject dbAccess, string databaseName, string tabName, string company, string project, string author, string className, string postfix, string tableName, string description)
            : this(dbAccess, databaseName, tabName)
        {
            this.company = company;
            this.project = project;
            this.author = author;
            this.className = className;
            this.postfix = postfix;
            this.TableName = tableName;
            this.description = description;
        }

        private void GetCodeCopyright()
        {
            this.CodeText = new StringBuilder();
            StringPlus StringP = new StringPlus();

            #region RDIFramework.NET-generated
            //------------------------------------------------------------------------------
            //     RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
            //     RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
            //工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
            //件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
            //
            //	框架官网：http://www.rdiframework.net/
            //	框架博客：http://blog.rdiframework.net/
            //	交流QQ：406590790 
            //	邮件交流：406590790@qq.com
            //	其他博客：
            //    http://www.cnblogs.com/huyong 
            //    http://blog.csdn.net/chinahuyong
            //------------------------------------------------------------------------------
            // <auto-generated>
            //     此代码由RDIFramework.NET平台代码生成工具自动生成。
            //     运行时版本:4.0.30319.1
            //
            //     对此文件的更改可能会导致不正确的行为，并且如果
            //     重新生成代码，这些更改将会丢失。
            // </auto-generated>
            //------------------------------------------------------------------------------
            #endregion

            this.CodeTextFormat.AppendLine("#region RDIFramework.NET-generated");
            this.CodeTextFormat.AppendLine("//------------------------------------------------------------------------------");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "RDIFramework.NET，是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendLine("工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendLine("件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。");
            this.CodeTextFormat.AppendLine("//");
            this.CodeTextFormat.AppendLine("// 框架官网：http://www.rdiframework.net/");
            this.CodeTextFormat.AppendLine("// 框架博客：http://blog.rdiframework.net/");
            this.CodeTextFormat.AppendLine("// 交流QQ：406590790 ");
            this.CodeTextFormat.AppendLine("// 邮件交流：406590790@qq.com");
            this.CodeTextFormat.AppendLine("// 其他博客：");
            this.CodeTextFormat.AppendLine("//      http://www.cnblogs.com/huyong ");
            this.CodeTextFormat.AppendLine("//      http://blog.csdn.net/chinahuyong");
            this.CodeTextFormat.AppendLine("//------------------------------------------------------------------------------");
            this.CodeTextFormat.AppendLine("// <auto-generated>");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "此代码由RDIFramework.NET平台代码生成工具自动生成。");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "运行时版本:4.0.30319.1");
            this.CodeTextFormat.AppendLine("//");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "对此文件的更改可能会导致不正确的行为，并且如果");
            this.CodeTextFormat.Append("//");
            this.CodeTextFormat.AppendSpaceLine(1, "重新生成代码，这些更改将会丢失。");
            this.CodeTextFormat.AppendLine("// </auto-generated>");
            this.CodeTextFormat.AppendLine("//------------------------------------------------------------------------------");
            this.CodeTextFormat.AppendLine("#endregion");
            this.CodeTextFormat.AppendLine(string.Empty);
            this.CodeText.Append(this.CodeTextFormat.ToString());
        }

        private void GetCodeUsing(bool table)
        {
            this.CodeText.AppendLine("using System;");
            this.CodeText.AppendLine("using System.Collections.Generic;");
            this.CodeText.AppendLine("using System.Linq;");
            if (MVCEntity)
            {
                this.CodeText.AppendLine("using System.Web.Mvc;");
                this.CodeText.AppendLine("using System.Web.Security;");
            }
            if (!table)
            {
                if (MVCEntity)
                {
                    this.CodeText.AppendLine("using System.ComponentModel;");
                    this.CodeText.AppendLine("using System.ComponentModel.DataAnnotations;");
                }
                this.CodeText.AppendLine("using System.Data;");
            }
        }

        private void GetCodeUsing()
        {
            this.GetCodeUsing(false);
        }

        private void GetCodeNamespace(string space, bool table)
        {
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.Append("namespace ");
            // 公司名做命名空间的一部分
            //if (!String.IsNullOrEmpty(this.company))
            //{
            //    this.CodeText.Append(this.company + ".");
            //}
            this.CodeText.Append(this.project + ".BizLogic");
            this.CodeText.AppendLine(string.Empty);
            this.CodeText.AppendLine("{");
            if (space.Equals("Manager") || space.Equals("Service"))
            {
                this.CodeText.AppendLine("    using RDIFramework.BizLogic;");
                this.CodeText.AppendLine("    using RDIFramework.Utilities;");
                this.CodeText.AppendLine(string.Empty);
            }
            else
            {
                if (table) return;
                this.CodeText.AppendLine("    using RDIFramework.BizLogic;");
                this.CodeText.AppendLine("    using RDIFramework.Utilities;");
                this.CodeText.AppendLine(string.Empty);
            }
        }

        private void GetCodeNamespace(string space)
        {
            this.GetCodeNamespace(space, false);
        }

        private void GetCodeRemark()
        {
            this.CodeText.AppendLine("    /// <summary>");
            this.CodeText.AppendLine("    /// " + this.className + this.postfix);
            this.CodeText.AppendLine("    /// " + this.description);
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// 修改纪录");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// " + this.dateCreated + " 版本：1.0 " + this.author + " 创建主键。");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// 版本：1.0");
            this.CodeText.AppendLine("    /// ");
            this.CodeText.AppendLine("    /// <author>");
            this.CodeText.AppendLine("    /// <name>" + this.author + "</name>");
            this.CodeText.AppendLine("    /// <date>" + this.dateCreated + "</date>");
            this.CodeText.AppendLine("    /// </author>");
            this.CodeText.AppendLine("    /// </summary>");
            if (this.postfix.Equals("Entity"))
            {
                if (!MVCEntity)
                {
                    this.CodeText.AppendLine("    [Serializable]");
                }
            }
        }

        private void GetCodeClassName()
        {
            switch (this.postfix)
            {
                case "Table":
                    this.CodeText.AppendLine("    public partial class " + this.className + "Table");
                    break;
                case "Entity":
                    if (MVCEntity)
                    {
                        this.CodeText.AppendLine("    [Bind(Exclude = \"" + this.PrimaryKey + "\")]");
                    }
                    this.CodeText.AppendLine("    public partial class " + this.className + "Entity : BaseEntity");
                    break;
                case "Manager":
                    this.CodeText.AppendLine("    public partial class " + this.className + this.postfix + " : DbCommonManager");//, IDbCommonManager");
                    break;
                default:
                    this.CodeText.AppendLine("    public class " + this.className + this.postfix);
                    break;
            }

            this.CodeText.AppendLine("    {");
        }

        public List<ColumnInfo> GetColumnInfo(string tableName = null)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = this.TableName;
            }
            return dbObject.GetColumnInfoList(this.DBName,tableName);
        }

        /// <summary>
        /// 获取当前表的主键
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKey(List<ColumnInfo> columnsInfo)
        {
            string primaryKey = string.Empty;
            foreach (ColumnInfo fieldInfo in columnsInfo.Where(fieldInfo => fieldInfo.IsPK))
            {
                primaryKey = fieldInfo.ColumnName;
                break;
            }
            return primaryKey;
        }


        /// <summary>
        /// 判断是否关键字
        /// </summary>
        /// <param name="field">字段</param>
        /// <returns>是关键字</returns>
        public bool IsKeywords(ref string field, bool allKeywords = false)
        {
            bool returnValue = false;
            // 首字母进行强制大写改进
            field = field.Substring(0, 1).ToUpper() + field.Substring(1);

            string[] keywords = { this.PrimaryKey, "CreateOn", "CreateUserId", "CreateBy", "ModifiedOn", "ModifiedUserId", "ModifiedBy" };
            if (allKeywords)
            {
                keywords = new string[] { this.PrimaryKey, "Code", "AuditStatus", "SortCode", "DeleteMark", "Enabled", "CreateOn", "CreateUserId", "CreateBy", "ModifiedOn", "ModifiedUserId", "ModifiedBy" };
            }

            for (int y = 0; y < keywords.Length; y++)
            {
                // 防止大小写问题发生
                if (keywords[y].ToUpper().Equals(field.ToUpper()))
                {
                    // 进行大小写转换
                    field = keywords[y];
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region private void GetCodeEntityManager(List<ColumnInfo> columnsInfo) 获取字段的写法
        /// <summary>
        /// 获取字段的写法
        /// </summary>
        /// <param name="xmlNode">文档</param>
        private void GetCodeEntityManager(List<ColumnInfo> columnsInfo)
        {
            foreach (ColumnInfo fieldInfo in columnsInfo)
            {
                bool isFilter = false;
                string field = fieldInfo.ColumnName;
                isFilter = IsKeywords(ref field);
                if (!isFilter)
                {
                    this.CodeText.AppendLine("            sqlBuilder.SetValue(" + this.className + "Table.Field" + field + ", " + this.ClassEntity + "." + field + ");");
                }
            }           
        }
        #endregion

        /// <summary>
        /// 获取字段的写法
        /// </summary>
        /// <param name="fieldsInfo"></param>
        private void GetCodeEntityColumn(List<ColumnInfo> fieldsInfo)
        {
            foreach (ColumnInfo column in fieldsInfo)
            {
                string field = column.ColumnName;
                string fieldDescription = column.ColDescription;
                string fieldDataType = column.TypeName;
                string fieldName = column.ColumnName;
                string fieldDefaultValue = column.DefaultVal;
                bool allowNull = column.IsNull;
                if (String.IsNullOrEmpty(fieldDescription))
                {
                    fieldDescription = fieldName;
                }
                // 关键字转换
                this.IsKeywords(ref field);
                // 这里是判断各个类型的，默认值等等
                //string defaultValue = string.Empty;
                string defaultValue = fieldDefaultValue;
                string dataType = string.Empty;
                //dataType = GetDataType(fieldDataType, ref defaultValue);
                string mvcDataType = string.Empty;
                if (!MVCEntity)
                {
                    allowNull = true;  //非MVC实体，可空类型的全部在类型后加?
                }
                dataType = GetDataType(fieldDataType, ref defaultValue, allowNull, out mvcDataType);
                /*
                // 默认值处理不方便
                this.CodeText.AppendLine("        /// <summary>");
                this.CodeText.AppendLine("        /// " + fieldDescription);
                this.CodeText.AppendLine("        /// </summary>");
                this.CodeText.AppendLine("        public " + dataType + " " + field + " { get; set; }");
                */

                // 采用这个方式的好处是可以处理默认值
                /* V2.7的方式
                string privateField = field.Substring(0, 1).ToLower() + field.Substring(1);
                this.CodeText.AppendLine("        private " + dataType + " " + privateField + " = " + defaultValue + ";");
                this.CodeText.AppendLine("        /// <summary>");
                this.CodeText.AppendLine("        /// " + fieldDescription);
                this.CodeText.AppendLine("        /// </summary>");
                this.CodeText.AppendLine("        public " + dataType + " " + field);
                this.CodeText.AppendLine("        {");
                this.CodeText.AppendLine("            get");
                this.CodeText.AppendLine("            {");
                this.CodeText.AppendLine("                return this." + privateField + ";");
                this.CodeText.AppendLine("            }");
                this.CodeText.AppendLine("            set");
                this.CodeText.AppendLine("            {");
                this.CodeText.AppendLine("                this." + privateField + " = value;");
                this.CodeText.AppendLine("            }");
                this.CodeText.AppendLine("        }");

                this.CodeText.AppendLine(string.Empty);
                */

                //V2.8新的方式：
                string privateField = string.Empty;
                if (!MVCEntity)
                {
                    privateField = field.Substring(0, 1).ToLower() + field.Substring(1);

                    if (string.IsNullOrEmpty(defaultValue))
                    {
                        this.CodeText.AppendLine("        private " + dataType + " _" + privateField + ";");
                    }
                    else
                    {
                        this.CodeText.AppendLine("        private " + dataType + " _" + privateField + " = " + defaultValue + ";");
                    }
                }
                this.CodeText.AppendLine("        /// <summary>");

                if (fieldDescription.IndexOf("\r\n", System.StringComparison.Ordinal) >= 0)
                {
                    string[] sDescription = Regex.Split(fieldDescription, "\r\n", RegexOptions.IgnoreCase);
                    foreach (string s in sDescription)
                    {
                        this.CodeText.AppendLine("        /// " + s);
                    }
                }
                else
                {
                    this.CodeText.AppendLine("        /// " + fieldDescription);
                }
                this.CodeText.AppendLine("        /// </summary>");

                if (MVCEntity)
                {
                    if (this.PrimaryKey.Equals(field))
                    {
                        this.CodeText.AppendLine("        [Key] ");
                        this.CodeText.AppendLine("        [ScaffoldColumn(false)] ");
                    }
                    else
                    {
                        // 字符长度限制
                        if (dataType.Equals("String"))
                        {
                            this.CodeText.AppendLine("        [StringLength(" + column.Length + ", ErrorMessage = \"" + fieldDescription + "不能超过" + column.Length + "个字符\")] ");
                        }
                        // 显示的名称
                        this.CodeText.AppendLine("        [Display(Name = \"" + fieldDescription + "\")] ");
                        // 是否允许为空
                        if (!allowNull)
                        {
                            this.CodeText.AppendLine("        [Required(ErrorMessage = \"" + "需要输入" + fieldDescription + "\")]");
                        }
                        if (!string.IsNullOrEmpty(mvcDataType))
                        {
                            this.CodeText.AppendLine("        [DataType(" + mvcDataType + ")]");
                        }
                    }
                }

                // 是否用简化的 Get Set
                if (MVCEntity)
                {
                    this.CodeText.AppendLine("        public " + dataType + " " + field + " { get; set; } ");
                }
                else
                {
                    this.CodeText.AppendLine("        public " + dataType + " " + field);
                    this.CodeText.AppendLine("        {");
                    this.CodeText.AppendLine("            get");
                    this.CodeText.AppendLine("            {");
                    this.CodeText.AppendLine("                return _" + privateField + ";");
                    this.CodeText.AppendLine("            }");
                    this.CodeText.AppendLine("            set");
                    this.CodeText.AppendLine("            {");
                    this.CodeText.AppendLine("                _" + privateField + " = value;");
                    this.CodeText.AppendLine("            }");
                    this.CodeText.AppendLine("        }");
                }

                this.CodeText.AppendLine(string.Empty);
            }
        }

        /// <summary>
        /// 数据库类型映射关系（数据库类型、C#类型、默认值、读取函数、MVC验证对应类型）
        /// </summary>
        readonly string [,]  DataTypeMapping = {
                                    {"NVARCHAR", "String", "string.Empty", "ToString", "DataType.Text"},
                                    {"VARCHAR", "String", "string.Empty", "ToString", "DataType.Text"},
                                    {"VARCHAR2", "String", "string.Empty", "ToString", "DataType.Text"},
                                    {"CHAR", "String", "string.Empty", "ToString", "DataType.Text"},
                                    {"BIT", "Boolean", "", "ToBoolean", ""},   
                                    {"NTEXT", "String", "string.Empty", "ToString", "DataType.MultilineText"},
                                    {"TEXT", "String", "string.Empty", "ToString", "DataType.MultilineText"},
                                    {"CLOB", "String", "string.Empty", "ToString", ""},
                                    {"BLOB", "Byte[]", "null", "ToByte", ""},
                                    {"BFILE", "Byte[]", "null", "ToByte", ""},
                                    {"VARBINARY", "Byte[]", "null", "ToByte", ""},
                                    {"IMAGE", "Byte[]", "null", "ToByte", ""},
                                    
                                    {"INT", "int", "", "ToInt", "DataType.Currency"},
                                    {"INTEGER", "int", "", "ToInt", "DataType.Currency"},
                                    {"SMALLINT", "int", "", "ToInt", "DataType.Currency"},
                                    {"BIGINT", "long", "", "ToLong", "DataType.Currency"},
                                    {"TINYINT", "byte", "", "ToByteInt", "DataType.Currency"},
                                    {"NUMBER", "Decimal", "", "ToDecimal", "DataType.Currency"},
                                    {"DOUBLE", "double", "", "ToDouble", "DataType.Currency"},
                                    {"DECIMAL", "Decimal", "", "ToDecimal", "DataType.Currency"},
                                    {"NUMERIC", "Decimal", "", "ToDecimal", "DataType.Currency"},
                                    {"REAL", "Decimal", "", "ToDecimal", "DataType.Currency"},
                                    {"FLOAT", "float", "", "ToFloat", "DataType.Currency"},
                                    {"DATE", "DateTime", "", "ToDateTime", "DataType.Date"},
                                    {"DATETIME", "DateTime", "", "ToDateTime", "DataType.DateTime"},
                                    {"SMALLDATETIME", "DateTime", "", "ToDateTime", "DataType.DateTime"},
                                    
                                    {"INT?", "int?", "null", "ToNullableInt", ""},
                                    {"INTEGER?", "int?", "null", "ToNullableInt", ""},
                                    {"SMALLINT?", "int?", "null", "ToNullableInt",""},
                                    {"BIGINT?", "long?", "null", "ToNullableLong", ""},
                                    {"TINYINT?", "byte?", "null", "ToNullableByteInt", ""},
                                    {"NUMBER?", "Decimal?", "null", "ToNullableDecimal", ""},
                                    {"DOUBLE?", "double?", "null", "ToNullableDouble", ""},
                                    {"DECIMAL?", "Decimal?", "null", "ToNullableDecimal", ""},
                                    {"NUMERIC?", "Decimal?", "null", "ToNullableDecimal", ""},
                                    {"REAL?", "Decimal?", "null", "ToNullableDecimal", ""},
                                    {"FLOAT?", "float?", "null", "ToNullableFloat", ""},
                                    {"DATE?", "DateTime?", "null", "ToNullableDateTime", ""},
                                    {"DATETIME?", "DateTime?", "null", "ToNullableDateTime", ""},
                                    {"SMALLDATETIME?", "DateTime?", "null", "ToNullableDateTime", ""}    
                    };

        /// <summary>
        /// 获取字段的类型
        /// </summary>
        /// <param name="fieldDataType">数据库字段类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>数据类型</returns>
        private string GetDataType(string fieldDataType, ref string defaultValue)
        {
            // 这是默认值
            string returnValue = typeof(string).Name.ToString();
            // 这个是查找对比对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.ToUpper().IndexOf(DataTypeMapping[i, 0], System.StringComparison.OrdinalIgnoreCase) < 0) continue;
                returnValue = DataTypeMapping[i, 1];
                // 如果defaultValue 为空的话 读取默认的 默认值 add by XuWangBin 20110618
                if (string.IsNullOrEmpty(defaultValue))
                {
                    defaultValue = DataTypeMapping[i, 2];
                }
                else
                {
                    //定义dataTypeStr，并格式化
                    string dataType = string.Empty;
                    dataType = fieldDataType.IndexOf('(') > 0 ? fieldDataType.Substring(0, fieldDataType.IndexOf('(')).ToUpper() : fieldDataType.ToUpper();                        
                    switch (dataType)
                    {
                            // 如果是字符类型，加""
                        case "NVARCHAR2":
                        case "NVARCHAR":
                        case "VARCHAR2":
                        case "VARCHAR":
                        case "CHAR":
                        case "TEXT":
                        case "NTEXT":
                            defaultValue = "\"" + defaultValue + "\"";
                            break;
                        case "DATE":
                        case "DATETIME":
                        case "SMALLDATETIME":
                            if (!string.IsNullOrEmpty(defaultValue))
                            {
                                if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("GETDATE", StringComparison.OrdinalIgnoreCase)
                                    || defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("SYSDATE", StringComparison.OrdinalIgnoreCase))
                                    defaultValue = "DateTime.Now";
                            }
                            break;
                        case "BIT":
                            if (!string.IsNullOrEmpty(defaultValue))
                            {
                                if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("1"))
                                {
                                    defaultValue = "true";
                                }
                                if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("0"))
                                {
                                    defaultValue = "false";
                                }
                            }
                            break;
                            // 如果是数值类型，直接用defaultValue
                        case "INT":
                        case "INTEGER":
                        case "SMALLINT":
                        case "BIGINT":
                            if (!string.IsNullOrEmpty(defaultValue))
                            {
                                defaultValue = defaultValue.ToString().Replace("(", "").Replace(")", "");
                            }
                            break;
                    }
                }
                // 不循环了，提高效率
                break;
            }
            //如果 找不到 匹配的，则返回string 类型默认值为 null
            if (string.IsNullOrEmpty(defaultValue))
            {
                defaultValue = "string.Empty";
            }
            return returnValue;
        }

        /// <summary>
        /// 获取字段的类型
        /// </summary>
        /// <param name="fieldDataType">数据库字段类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>数据类型</returns>
        private string GetDataType(string fieldDataType, ref string defaultValue, bool allowNull, out string mvcDataType)
        {
            // 这是默认值
            string result = "string";
            mvcDataType = string.Empty;
            fieldDataType = fieldDataType.ToUpper();
            // 是否可为空的类型
            if (allowNull)
            {
                if (fieldDataType.Equals("INT")
                    || fieldDataType.Equals("SMALLINT")
                    || fieldDataType.Equals("INTEGER")
                    || fieldDataType.Equals("BIGINT")
                    || fieldDataType.Equals("TINYINT")
                    || fieldDataType.Equals("NUMBER")
                    || fieldDataType.Equals("DOUBLE")
                    || fieldDataType.Equals("DECIMAL")
                    || fieldDataType.Equals("NUMERIC")
                    || fieldDataType.Equals("REAL")
                    || fieldDataType.Equals("FLOAT")
                    || fieldDataType.Equals("DATE")
                    || fieldDataType.Equals("DATETIME")
                    || fieldDataType.Equals("SMALLDATETIME"))
                {
                    fieldDataType = fieldDataType + "?";
                }
            }
            // 这个是查找对比对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (DataTypeMapping[i, 0].IndexOf(fieldDataType, System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result = DataTypeMapping[i, 1];
                    mvcDataType = DataTypeMapping[i, 4];
                    // 如果defaultValue 为空的话 读取默认的 默认值 add by zgl 20110618
                    if (string.IsNullOrEmpty(defaultValue))
                    {
                        defaultValue = DataTypeMapping[i, 2];
                    }
                    else
                    {
                        //定义dataTypeStr，并格式化
                        string dataType = string.Empty;
                        if (fieldDataType.IndexOf('(') > 0)
                        {
                            dataType = fieldDataType.Substring(0, fieldDataType.IndexOf('(')).ToUpper();
                        }
                        else
                        {
                            dataType = fieldDataType.ToUpper();
                        }
                        switch (dataType.Replace("?",""))
                        {
                            // 如果是字符类型，加""
                            case "NVARCHAR2":
                            case "NVARCHAR":
                            case "VARCHAR2":
                            case "VARCHAR":
                            case "CHAR":
                            case "TEXT":
                            case "NTEXT":
                                if (!string.IsNullOrEmpty(defaultValue) && defaultValue.ToLower().Contains("newid"))
                                {
                                    defaultValue = "BusinessLogic.NewGuid()";
                                }
                                else
                                {
                                    defaultValue = "\"" + defaultValue.Replace("(", "").Replace(")", "").Replace("'","") + "\"";
                                }
                                break;
                            case "DATE":
                            case "DATETIME":
                            case "SMALLDATETIME":
                                if (!string.IsNullOrEmpty(defaultValue))
                                {
                                    if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("GETDATE", StringComparison.OrdinalIgnoreCase)
                                        || defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("SYSDATE", StringComparison.OrdinalIgnoreCase))
                                        defaultValue = "DateTime.Now";
                                }
                                break;
                            case "BIT":
                                if (!string.IsNullOrEmpty(defaultValue))
                                {
                                    if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("1"))
                                    {
                                        defaultValue = "true";
                                    }
                                    if (defaultValue.ToString().Replace("(", "").Replace(")", "").Equals("0"))
                                    {
                                        defaultValue = "false";
                                    }
                                }
                                break;
                            // 如果是数值类型，直接用defaultValue
                            case "INT":
                            case "INTEGER":
                            case "SMALLINT":
                            case "BIGINT":
                            case "REAL":
                                if (!string.IsNullOrEmpty(defaultValue))
                                {
                                    defaultValue = defaultValue.ToString().Replace("(", "").Replace(")", "");
                                }
                                break;
                        }
                    }
                    // 不循环了，提高效率
                    break;
                }
            }
            // 如果找不到 匹配的，则返回string 类型默认值为 null
            if (string.IsNullOrEmpty(result))
            {
                result = "string.Empty";
            }
            return result;
        }

        private string GetDataType(string fieldDataType)
        {
            // 这是默认值
            string returnValue = typeof(string).Name.ToString();
            // 这个是差找对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.IndexOf(DataTypeMapping[i, 0], System.StringComparison.OrdinalIgnoreCase) < 0) continue;
                returnValue = DataTypeMapping[i, 1];
                // 不循环了，提高效率
                break;
            }
            return returnValue;
        }

        public string GetColumnDataType(List<ColumnInfo> columnsInfo, string columnName, bool dbDataType = false)
        {
            string fieldDataType = string.Empty;
            foreach (ColumnInfo fieldInfo in columnsInfo.Where(fieldInfo => fieldInfo.ColumnName.ToUpper() == columnName.ToUpper()))
            {
                fieldDataType = fieldInfo.TypeName;
                break;
            }
            fieldDataType = GetDataType(fieldDataType);
            if (dbDataType)
            {
                fieldDataType = fieldDataType.TrimEnd('?');
                fieldDataType = fieldDataType.TrimEnd(']');
                fieldDataType = fieldDataType.TrimEnd('[');
            }
            return fieldDataType;
        }

        private string GetToStringFunction(string dataType)
        {
            // 这是默认值
            string returnValue = string.Empty;
            switch (dataType.ToUpper())
            {
                case "INT":
                case "TINYINT":
                case "INTEGER":
                case "BIGINT":
                case "DECIMAL":
                case "NUMERIC":
                    returnValue = ".ToString()";
                    break;
                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                    returnValue = "ToString(SystemInfo.DateFormat)";
                    break;
                case "NVARCHAR2":
                case "NVARCHAR":
                case "VARCHAR2":
                case "VARCHAR":
                case "CHAR":
                case "TEXT":
                case "NTEXT":
                case "BIT":
                    break;
            }
            return returnValue;
        }

        private string GetConvertFunction(string fieldDataType)
        {
            int indexOf = fieldDataType.IndexOf('(');
            if (indexOf > 0)
            {
                fieldDataType = fieldDataType.Substring(0, indexOf);
            }
            // 这是默认值
            string returnValue = "ToString";
            // 这个是差找对比
            for (int i = 0; i < DataTypeMapping.GetLength(0); i++)
            {
                if (fieldDataType.ToLower().IndexOf(DataTypeMapping[i, 0].ToLower()) < 0) continue;
                returnValue = DataTypeMapping[i, 3];
                // 不循环了，提高效率
                break;
            }
            return returnValue;
        }
        
        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fieldsInfo"></param>
        /// <param name="columnName">列名</param>
        /// <returns>存在</returns>
        private bool ColumnsExists(List<ColumnInfo> fieldsInfo, string columnName)
        {
            return fieldsInfo.Any(field => field.ColumnName.ToUpper().Equals(columnName.ToUpper()));
        }

        private void GetCodeEnd()
        {
            this.CodeText.AppendLine("    }");
            this.CodeText.Append("}");
        }

        #region public static void WriteCode(string fileName, bool overwrite, string code) 写入主键
        /// <summary>
        /// 写入主键
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="overwrite">覆盖</param>
        /// <param name="code">主键</param>
        /// <returns>成功</returns>
        public static bool WriteCode(string fileName, bool overwrite, string code)
        {
            bool returnValue = overwrite;
            if (File.Exists(fileName))
            {
                if (!overwrite)
                {
                    return returnValue;
                }
            }
            else
            {
                string path = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fileStream.Close();
            }
            StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
            streamWriter.WriteLine(code);
            streamWriter.Close();
            return returnValue;
        }
        #endregion
    }
}
