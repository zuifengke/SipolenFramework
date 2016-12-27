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
    /// OperatorManager
    /// 处理者
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
    public partial class OperatorManager : DbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OperatorManager()
        {
            base.CurrentTableName = OperatorTable.TableName;
            base.PrimaryKey = OperatorTable.FieldOperatorId;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public OperatorManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public OperatorManager(IDbProvider dbProvider): this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public OperatorManager(UserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public OperatorManager(IDbProvider dbProvider, UserInfo userInfo) : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public OperatorManager(IDbProvider dbProvider, UserInfo userInfo, string tableName) : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="operatorEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(OperatorEntity operatorEntity)
        {
            return this.AddEntity(operatorEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="operatorEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(OperatorEntity operatorEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(operatorEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="operatorEntity">实体</param>
        public int Update(OperatorEntity operatorEntity)
        {
            return this.UpdateEntity(operatorEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public OperatorEntity GetEntity(string id)
        {
            return BaseEntity.Create<OperatorEntity>(this.GetDT(new KeyValuePair<string, object>(OperatorTable.FieldOperatorId, id)));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="operatorEntity">实体</param>
        public string AddEntity(OperatorEntity operatorEntity)
        {
            var sequence = string.Empty;
            this.Identity = false; 
            if (operatorEntity.OperatorId != null)
            {
                sequence = operatorEntity.OperatorId.ToString(CultureInfo.InvariantCulture);
            }
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, OperatorTable.FieldOperatorId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(operatorEntity.OperatorId)) 
                { 
                    sequence = BusinessLogic.NewGuid(); 
                    operatorEntity.OperatorId = sequence ;
                }
                sqlBuilder.SetValue(OperatorTable.FieldOperatorId, operatorEntity.OperatorId);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(OperatorTable.FieldOperatorId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(OperatorTable.FieldOperatorId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(operatorEntity.OperatorId))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            operatorEntity.OperatorId = sequence;
                        }
                        sqlBuilder.SetValue(OperatorTable.FieldOperatorId, operatorEntity.OperatorId);
                    }
                }
            }
            this.SetEntity(sqlBuilder, operatorEntity);
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
        /// <param name="operatorEntity">实体</param>
        public int UpdateEntity(OperatorEntity operatorEntity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, operatorEntity);
            sqlBuilder.SetWhere(OperatorTable.FieldOperatorId, operatorEntity.OperatorId);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">Sql语句生成器</param>
        /// <param name="operatorEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, OperatorEntity operatorEntity)
        {
            sqlBuilder.SetValue(OperatorTable.FieldWorkFlowId, operatorEntity.WorkFlowId);
            sqlBuilder.SetValue(OperatorTable.FieldWorkTaskId, operatorEntity.WorkTaskId);
            sqlBuilder.SetValue(OperatorTable.FieldNextType, operatorEntity.NextType);
            sqlBuilder.SetValue(OperatorTable.FieldOperType, operatorEntity.OperType);
            sqlBuilder.SetValue(OperatorTable.FieldOperContent, operatorEntity.OperContent);
            sqlBuilder.SetValue(OperatorTable.FieldRelation, operatorEntity.Relation);
            sqlBuilder.SetValue(OperatorTable.FieldDescription, operatorEntity.Description);
            sqlBuilder.SetValue(OperatorTable.FieldOperDisplay, operatorEntity.OperDisplay);
            sqlBuilder.SetValue(OperatorTable.FieldInorExclude, operatorEntity.InorExclude);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(OperatorTable.FieldOperatorId, id));
        }
    }
}
