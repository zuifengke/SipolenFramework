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

namespace RDIFramework.BizLogic
{
    
    using RDIFramework.Utilities;

    /// <summary>
    /// AuditMessageManager
    /// 
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
    public partial class AuditMessageManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AuditMessageManager()
        {
            base.CurrentTableName = AuditMessageTable.TableName;
            base.PrimaryKey = AuditMessageTable.FieldAuditId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public AuditMessageManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public AuditMessageManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public AuditMessageManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public AuditMessageManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public AuditMessageManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="auditMessageEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(AuditMessageEntity auditMessageEntity)
        {
            return this.AddEntity(auditMessageEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="auditMessageEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(AuditMessageEntity auditMessageEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(auditMessageEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="auditMessageEntity">实体</param>
        public int Update(AuditMessageEntity auditMessageEntity)
        {
            return this.UpdateEntity(auditMessageEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public AuditMessageEntity GetEntity(string id)
        {
            AuditMessageEntity auditMessageEntity = BaseEntity.Create<AuditMessageEntity>(this.GetDT(new KeyValuePair<string, object>(AuditMessageTable.FieldAuditId, id)));
            return auditMessageEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="auditMessageEntity">实体</param>
        public string AddEntity(AuditMessageEntity auditMessageEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (auditMessageEntity.AuditId != null)
            {
                sequence = auditMessageEntity.AuditId.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, AuditMessageTable.FieldAuditId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(auditMessageEntity.AuditId)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    auditMessageEntity.AuditId = sequence ;
                }
                sqlBuilder.SetValue(AuditMessageTable.FieldAuditId, auditMessageEntity.AuditId);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(AuditMessageTable.FieldAuditId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(AuditMessageTable.FieldAuditId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(auditMessageEntity.AuditId))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            auditMessageEntity.AuditId = sequence;
                        }
                        sqlBuilder.SetValue(AuditMessageTable.FieldAuditId, auditMessageEntity.AuditId);
                    }
                }
            }
            this.SetEntity(sqlBuilder, auditMessageEntity);
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
        /// <param name="auditMessageEntity">实体</param>
        public int UpdateEntity(AuditMessageEntity auditMessageEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, auditMessageEntity);
            sqlBuilder.SetWhere(AuditMessageTable.FieldAuditId, auditMessageEntity.AuditId);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="auditMessageEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, AuditMessageEntity auditMessageEntity)
        {
            sqlBuilder.SetValue(AuditMessageTable.FieldWorkflowId, auditMessageEntity.WorkflowId);
            sqlBuilder.SetValue(AuditMessageTable.FieldWorkflowInsId, auditMessageEntity.WorkflowInsId);
            sqlBuilder.SetValue(AuditMessageTable.FieldWorktaskId, auditMessageEntity.WorktaskId);
            sqlBuilder.SetValue(AuditMessageTable.FieldWorktaskInsId, auditMessageEntity.WorktaskInsId);
            sqlBuilder.SetValue(AuditMessageTable.FieldOperatorInsId, auditMessageEntity.OperatorInsId);
            sqlBuilder.SetValue(AuditMessageTable.FieldMessage, auditMessageEntity.Message);
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditUserId, auditMessageEntity.AuditUserId);
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditUserName, auditMessageEntity.AuditUserName);
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditDuty, auditMessageEntity.AuditDuty);
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditArch, auditMessageEntity.AuditArch);
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditResult, auditMessageEntity.AuditResult);
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlBuilder.SetValue(AuditMessageTable.FieldAuditTime, auditMessageEntity.AuditTime != null ? BusinessLogic.GetOracleDateFormat(System.DateTime.Parse(auditMessageEntity.AuditTime.ToString()), "yyyy-mm-dd hh24:mi:ss") : auditMessageEntity.AuditTime);
            }
            else
            {
                sqlBuilder.SetValue(AuditMessageTable.FieldAuditTime, auditMessageEntity.AuditTime);
            }
            
            sqlBuilder.SetValue(AuditMessageTable.FieldAuditXYB, auditMessageEntity.AuditXYB);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(AuditMessageTable.FieldAuditId, id));
        }
    }
}
