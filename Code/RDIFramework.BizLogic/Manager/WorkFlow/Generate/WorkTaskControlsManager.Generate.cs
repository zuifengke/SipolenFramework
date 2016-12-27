﻿#region RDIFramework.NET-generated
//------------------------------------------------------------------------------
//	RDIFramework.NET（.NET快速信息化系统开发、整合框架）是基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。
//	RDIFramework.NET平台包含基础公共类库、强大的权限控制、模块分配、数据字典、自动升级、各商业级控件库、工作流平台、代码生成器、开发辅助
//工具等，应用系统的各个业务功能子系统，在系统体系结构设计的过程中被设计成各个原子功能模块，各个子功能模块按照业务功能组织成单独的程序集文
//件，各子系统开发完成后，由RDIFramework.NET平台进行统一的集成部署。
//
// 官方博客：http://www.cnblogs.com/huyong
//           http://blog.csdn.net/chinahuyong
//    Email：80368704@qq.com
//       QQ：80368704
//------------------------------------------------------------------------------
// <auto-generated>
//	此代码由RDIFramework.NET平台代码生成工具自动生成。
//	运行时版本:4.0.30319.1
//
//	对此文件的更改可能会导致不正确的行为，并且如果
//	重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using System.Globalization;

namespace RDIFramework.BizLogic
{    
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkTaskControlsManager
    /// 任务表单
    /// 
    /// 修改纪录
    /// 
    /// 2014-06-03 版本：1.0 XuWangBin 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>XuWangBin</name>
    /// <date>2014-06-03</date>
    /// </author>
    /// </summary>
    public partial class WorkTaskControlsManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkTaskControlsManager()
        {
            base.CurrentTableName = WorkTaskControlsTable.TableName;
            base.PrimaryKey = WorkTaskControlsTable.FieldTaskControlId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public WorkTaskControlsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public WorkTaskControlsManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public WorkTaskControlsManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public WorkTaskControlsManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public WorkTaskControlsManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="workTaskControlsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(WorkTaskControlsEntity workTaskControlsEntity)
        {
            return this.AddEntity(workTaskControlsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="workTaskControlsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(WorkTaskControlsEntity workTaskControlsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(workTaskControlsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="workTaskControlsEntity">实体</param>
        public int Update(WorkTaskControlsEntity workTaskControlsEntity)
        {
            return this.UpdateEntity(workTaskControlsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public WorkTaskControlsEntity GetEntity(string id)
        {
            return BaseEntity.Create<WorkTaskControlsEntity>(this.GetDT(new KeyValuePair<string, object>(WorkTaskControlsTable.FieldTaskControlId, id)));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="workTaskControlsEntity">实体</param>
        public string AddEntity(WorkTaskControlsEntity workTaskControlsEntity)
        {
            var sequence = string.Empty;
            this.Identity = false; 
            if ( !string.IsNullOrEmpty(workTaskControlsEntity.TaskControlId))
            {
                sequence = workTaskControlsEntity.TaskControlId.ToString(CultureInfo.InvariantCulture);
            }
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, WorkTaskControlsTable.FieldTaskControlId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(workTaskControlsEntity.TaskControlId)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    workTaskControlsEntity.TaskControlId = sequence ;
                }
                sqlBuilder.SetValue(WorkTaskControlsTable.FieldTaskControlId, workTaskControlsEntity.TaskControlId);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(WorkTaskControlsTable.FieldTaskControlId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(WorkTaskControlsTable.FieldTaskControlId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(workTaskControlsEntity.TaskControlId))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            workTaskControlsEntity.TaskControlId = sequence;
                        }
                        sqlBuilder.SetValue(WorkTaskControlsTable.FieldTaskControlId, workTaskControlsEntity.TaskControlId);
                    }
                }
            }
            this.SetEntity(sqlBuilder, workTaskControlsEntity);
            if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="workTaskControlsEntity">实体</param>
        public int UpdateEntity(WorkTaskControlsEntity workTaskControlsEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, workTaskControlsEntity);
            sqlBuilder.SetWhere(WorkTaskControlsTable.FieldTaskControlId, workTaskControlsEntity.TaskControlId);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">Sql语句生成器</param>
        /// <param name="workTaskControlsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, WorkTaskControlsEntity workTaskControlsEntity)
        {
            sqlBuilder.SetValue(WorkTaskControlsTable.FieldWorkflowId, workTaskControlsEntity.WorkflowId);
            sqlBuilder.SetValue(WorkTaskControlsTable.FieldWorkTaskId, workTaskControlsEntity.WorkTaskId);
            sqlBuilder.SetValue(WorkTaskControlsTable.FieldUserControlId, workTaskControlsEntity.UserControlId);
            sqlBuilder.SetValue(WorkTaskControlsTable.FieldControlType, workTaskControlsEntity.ControlType);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(WorkTaskControlsTable.FieldTaskControlId, id));
        }
    }
}
