﻿#region RDIFramework.NET-generated
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

using System;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// OperatorInstanceEntity
    /// 处理者实例
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：3.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class OperatorInstanceEntity : BaseEntity
    {
        /// <summary>
        /// 处理者实例主键
        /// </summary>
        public String OperatorInsId { get; set; }

        /// <summary>
        /// 所属流程模版
        /// </summary>
        public String WorkFlowId { get; set; }

        /// <summary>
        /// 所属任务模版
        /// </summary>
        public String WorkTaskId { get; set; }

        /// <summary>
        /// 所属流程实例
        /// </summary>
        public String WorkFlowInsId { get; set; }

        /// <summary>
        /// 所属任务实例
        /// </summary>
        public String WorkTaskInsId { get; set; }

        /// <summary>
        /// 实际处理人Id，该事例的实际处理人可能与模板指定的处理人不一样，例如指派或授权后。
        /// </summary>
        public String UserId { get; set; }
       
        /// <summary>
        /// 处理人类型
        /// </summary>
        public int? OperType { get; set; }

        /// <summary>
        /// 处理者关系，从流程莫版中原样复制。
        /// </summary>
        public int? OperRealtion { get; set; }
       
        /// <summary>
        /// 理者id，根据流程模板生成的处理者实例
        /// </summary>
        public String OperContent { get; set; }

        /// <summary>
        /// 名字，部门或者角色名称，与OperContent对应。
        /// </summary>
        public String OperContentText { get; set; }

        /// <summary>
        /// 表示处理者状态
        ///  0 未处理，也未认领
        ///  1 处理完成
        ///  2 指派他人（此时产生一个新的处理人实例）
        ///  3 已经认领，但还未处理   
        /// </summary>
        public String OperStatus { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? OperDateTime { get; set; }

        /// <summary>
        /// 如果被指派人，此处存放被指派人的Userid
        /// </summary>
        public String ChangeOperator { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public OperatorInstanceEntity()
        {
            this.OperType = null;
            this.OperRealtion = null;
            this.OperStatus = "0";
            this.OperDateTime = null;
            this.ChangeOperator = "0";
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.OperatorInsId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldOperatorInsId]);
            this.WorkFlowId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldWorkFlowId]);
            this.WorkTaskId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldWorkTaskId]);
            this.WorkFlowInsId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldWorkFlowInsId]);
            this.WorkTaskInsId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldWorkTaskInsId]);
            this.UserId = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldUserId]);
            this.OperType = BusinessLogic.ConvertToNullableInt(dataRow[OperatorInstanceTable.FieldOperType]);
            this.OperRealtion = BusinessLogic.ConvertToNullableInt(dataRow[OperatorInstanceTable.FieldOperRealtion]);
            this.OperContent = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldOperContent]);
            this.OperContentText = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldOperContentText]);
            this.OperStatus = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldOperStatus]);
            this.OperDateTime = BusinessLogic.ConvertToNullableDateTime(dataRow[OperatorInstanceTable.FieldOperDateTime]);
            this.ChangeOperator = BusinessLogic.ConvertToString(dataRow[OperatorInstanceTable.FieldChangeOperator]);
            return this;
        }
    }
}
