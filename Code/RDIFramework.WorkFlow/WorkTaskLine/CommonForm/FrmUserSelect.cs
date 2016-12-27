﻿using System;
using System.Data;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserSelect
    /// 用户选择公共界面
    /// 
    /// 修改记录
    ///     XuWangBin 2014-06-18 v2.8 对用户选择界面进行重构。
    /// 
    /// </summary>
    public partial class FrmUserSelect : BaseForm
    {
        private DataTable DTUserList = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds { get; set; }

        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectedIds { get; set; }

        public string CheckPermissionFullName = string.Empty;   // 检查什么模块
        public string CheckModuleCode = string.Empty;   // 检查什么模块
        public string CheckOperationCode = string.Empty;   // 检查什么权限

        public bool AllowSelectOther = true;

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull { get; set; }

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }
       
        /// <summary>
        /// 按什么权限域获取用户列表
        /// </summary>
        public string PermissionScopeCode { get; set; }
       
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string SelectedId { get; set; }

        /// <summary>
        /// 被选中的员工全名
        /// </summary>
        public string SelectedFullName { get; set; }
      
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizeId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 被选中的用户主键
        /// </summary>
        public string[] UserIds { get; set; }

        /// <summary>
        /// 被选中的用户主键数组
        /// </summary>
        public string[] SelectedIds { get; set; }

        public delegate bool ButtonConfirmEventHandler();

        public FrmUserSelect()
        {
            InitializeComponent();
        }

        #region private void GetList(string searchValue) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void GetList(string searchValue)
        {
            RDIFrameworkService Service = new RDIFrameworkService();
            if (this.UserIds != null && this.UserIds.Length > 1)
            {
                this.DTUserList = Service.UserService.GetDTByIds(this.UserInfo, this.UserIds);
            }
            else
            {
                int recordCount = 0;
                this.DTUserList = Service.UserService.GetDTByPage(UserInfo, searchValue, this.OrganizeId, this.RoleId, out recordCount, ucPager.PageIndex, ucPager.PageSize, PiUserTable.TableName + "." + PiUserTable.FieldSortCode);
                ucPager.RecordCount = recordCount;
                ucPager.InitPageInfo();
            }
            CloseCommunicationObject(Service.StaffService);

            this.DTUserList.PrimaryKey = new DataColumn[] { this.DTUserList.Columns[PiUserTable.FieldId] };
            this.dgvUser.DataSource = this.DTUserList;
        }
        #endregion

        private void RemoveUser(string[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DataRow dr = DTUserList.Rows.Find(ids[i]);
                    if (dr != null)
                    {
                        dr.Delete();
                    }
                }
                DTUserList.AcceptChanges();
            }
        }

        #region private void GetRoles() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dt = RDIFrameworkService.Instance.RoleService.GetApplicationRole(UserInfo);
            BusinessLogic.SetFilter(dt, PiRoleTable.FieldDeleteMark, "0");
            BusinessLogic.SetFilter(dt, PiRoleTable.FieldEnabled, "1");
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            this.cboRole.DisplayMember = PiRoleTable.FieldRealName;
            this.cboRole.ValueMember = PiRoleTable.FieldId;
            this.cboRole.DataSource = dt.DefaultView;
        }
        #endregion

        private void SetSelect()
        {
            // 检查选中状态
            if (this.SelectedIds != null && this.SelectedIds.Length > 0)
            {
                foreach (DataRow dr in this.DTUserList.Rows)
                {
                    if (dr.RowState == DataRowState.Deleted)
                    {
                        continue;
                    }
                    string id = dr[PiUserTable.FieldId].ToString();
                    if (Array.Exists(SelectedIds, element => element.Equals(id)))
                    {
                        dr[BusinessLogic.SelectedColumn] = true;
                    }
                }
            }
        }

        #region public override void FormOnLoad()
        public override void FormOnLoad()
        {
            this.FormLoaded = false;
            // 获取角色列表
            this.GetRoles();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvUser);
            this.dgvUser.AutoGenerateColumns = false;
            this.Search();
            this.FormLoaded = true;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSetNull.Enabled = this.AllowNull;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnSelect.Enabled = false;
            //this.btnSelect.Visible = this.OnSelected != null;
            if (!this.MultiSelect)
            {
                this.btnSelectAll.Visible = false;
                this.btnInvertSelect.Visible = false;
            }
            this.btnSelect.Enabled = false;

            if (this.DTUserList.Rows.Count > 0)
            {
                if (this.MultiSelect)
                {
                    this.btnSelectAll.Enabled = true;
                    this.btnInvertSelect.Enabled = true;
                }
                this.btnSelect.Enabled = true;
                this.btnSelectAll.Enabled = true;
            }
            this.txtSearch.Visible = this.AllowSelectOther;
            this.btnSearch.Visible = this.AllowSelectOther;
            if ((this.btnSearch.Visible) && (!UserInfo.IsAdministrator))
            {
                this.btnSearch.Enabled = String.IsNullOrEmpty(this.PermissionScopeCode);
            }
        }
        #endregion

        private void SetRowFilter()
        {
            string search = this.txtSearch.Text.Trim();
            if (!String.IsNullOrEmpty(search))
            {
                if (this.DTUserList.Rows.Count > 0)
                {
                    search = StringHelper.GetSearchString(search);
                    this.DTUserList.DefaultView.RowFilter = StringHelper.GetLike(PiUserTable.FieldUserName, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldCode, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldRealName, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldQuickQuery, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldDescription, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldCompanyName, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldDepartmentName, search)
                        + " OR " + StringHelper.GetLike(PiUserTable.FieldDescription, search);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SetRowFilter();
        }

        /// <summary>
        /// 往DataTable里面添加一列
        /// </summary>
        private void DataTableAddColumn(DataTable dt)
        {
            if (!dt.Columns.Contains(BusinessLogic.SelectedColumn))
            {
                BasePageLogic.DataTableAddColumn(dt, BusinessLogic.SelectedColumn, typeof(bool));
            }
            //设置表主键
            DataColumn[] primaryKey = new DataColumn[] { dt.Columns[PiUserTable.FieldId] };
            dt.PrimaryKey = primaryKey;
            // 未必选中状态
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTUserList.Rows[i][BusinessLogic.SelectedColumn] = false;
            }
            dt.AcceptChanges();
        }

        private void Search()
        {
            this.btnSearch.Enabled = false;
            string searchValue = this.txtSearch.Text;
            // 加载数据
            this.GetList(searchValue);
            // 检查是否需要移出
            this.RemoveUser(this.RemoveIds);
            DataTableAddColumn(this.DTUserList);
            this.SetSelect();
            // 设置按钮状态
            this.SetControlState();
            this.btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void GetUsers(string departmentId, string roleId)
        {
            if (!string.IsNullOrEmpty(departmentId))
            {
                this.DTUserList = RDIFrameworkService.Instance.UserService.GetDTByDepartment(UserInfo, departmentId, true);
            }
            else if (!string.IsNullOrEmpty(roleId))
            {
                this.DTUserList = RDIFrameworkService.Instance.UserService.GetDTByRole(UserInfo, roleId);
            }
            this.DTUserList.PrimaryKey = new DataColumn[] { this.DTUserList.Columns[PiRoleTable.FieldId] };
            this.DTUserList.AcceptChanges();
            this.DTUserList.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.SetRowFilter();
            this.dgvUser.DataSource = this.DTUserList;
            this.SetControlState();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.RoleId = this.cboRole.SelectedValue.ToString();
                this.Search();
            }
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MultiSelect)
            {
                // 默认选中状态
                DataRow dr = BasePageLogic.GetDataGridViewEntity(this.dgvUser);
                if (dr != null)
                {
                    dr[BusinessLogic.SelectedColumn] = true;
                    // 点击确认按钮
                    this.btnSelect.PerformClick();
                }
            }
            else
            {
                DataRow dr = BasePageLogic.GetDataGridViewEntity(this.dgvUser);
                if (dr != null)
                {
                    this.SelectedId = dr[PiUserTable.FieldId].ToString();
                    this.SelectedFullName = dr[PiUserTable.FieldRealName].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }


        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DTUserList.Rows.Count; i++)
            {
                DTUserList.Rows[i][BusinessLogic.SelectedColumn] = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DTUserList.Rows.Count; i++)
            {
                if (DTUserList.Rows[i][BusinessLogic.SelectedColumn].ToString() == true.ToString())
                {
                    DTUserList.Rows[i][BusinessLogic.SelectedColumn] = false;
                }
                else
                {
                    DTUserList.Rows[i][BusinessLogic.SelectedColumn] = true;
                }
            }
        }
        private string[] GetSelectedFullNames()
        {
            return BasePageLogic.GetSelecteIds(this.DTUserList.DefaultView, PiUserTable.FieldRealName, BusinessLogic.SelectedColumn, true);
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns>主键组</returns>
        private string[] GetSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.DTUserList.DefaultView, PiUserTable.FieldId, BusinessLogic.SelectedColumn, true);
        }
        #endregion

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.SelectedIds = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region private void GetSelectedId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelectedId()
        {
            DataRow dr = BasePageLogic.GetDataGridViewEntity(this.dgvUser);
            if (dr != null)
            {
                this.SelectedId = dr[PiUserTable.FieldId].ToString();
                this.SelectedFullName = dr[PiUserTable.FieldRealName].ToString();
            }
        }
        #endregion

        private void SelectSingle()
        {
            if (BasePageLogic.CheckInputSelectOne(this.DTUserList, BusinessLogic.SelectedColumn))
            {
                DataRow dr = BasePageLogic.GetDataGridViewEntity(this.dgvUser);
                if (dr != null)
                {
                    this.GetSelectedId();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 选择用户
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SelectMulti(bool close = true)
        {
            if (BasePageLogic.CheckInputSelectAnyOne(this.DTUserList, BusinessLogic.SelectedColumn))
            {
                this.SelectedIds = this.GetSelectedIds();
                this.SelectedFullName = BusinessLogic.ObjectsToList(this.GetSelectedFullNames());
                if (!close)
                {
                    if (this.OnSelected != null)
                    {
                        // 进行委托处理
                        if (this.OnSelected(this.SelectedIds))
                        {
                            this.RemoveUser(this.SelectedIds);
                            this.SelectedIds = null;
                        }
                        // 清除选中的数据
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 添加的用户主键
        /// </summary>
        /// <param name="selectedIds">选择的主键数组</param>
        /// <returns>是否成功</returns>
        public delegate bool OnSelectedEventHandler(string[] selectedIds);

        public event OnSelectedEventHandler OnSelected;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                // 选择好后，关闭窗体
                this.SelectMulti(true);
            }
            else
            {
                this.SelectSingle();
            }
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            this.Search();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
