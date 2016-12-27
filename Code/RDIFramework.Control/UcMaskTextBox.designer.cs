﻿/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:33:14
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:32:19
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcMaskTextBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlBorder = new System.Windows.Forms.Panel();
            this.PnlWhiteBG = new System.Windows.Forms.Panel();
            this.txtInside = new System.Windows.Forms.MaskedTextBox();
            this.PnlImageBG = new System.Windows.Forms.Panel();
            this.PnlBorder.SuspendLayout();
            this.PnlWhiteBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBorder
            // 
            this.PnlBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.PnlBorder.Controls.Add(this.PnlWhiteBG);
            this.PnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBorder.Location = new System.Drawing.Point(1, 1);
            this.PnlBorder.Name = "PnlBorder";
            this.PnlBorder.Padding = new System.Windows.Forms.Padding(1);
            this.PnlBorder.Size = new System.Drawing.Size(162, 25);
            this.PnlBorder.TabIndex = 0;
            // 
            // PnlWhiteBG
            // 
            this.PnlWhiteBG.BackColor = System.Drawing.Color.White;
            this.PnlWhiteBG.Controls.Add(this.txtInside);
            this.PnlWhiteBG.Controls.Add(this.PnlImageBG);
            this.PnlWhiteBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlWhiteBG.Location = new System.Drawing.Point(1, 1);
            this.PnlWhiteBG.Name = "PnlWhiteBG";
            this.PnlWhiteBG.Size = new System.Drawing.Size(160, 23);
            this.PnlWhiteBG.TabIndex = 0;
            // 
            // txtInside
            // 
            this.txtInside.BackColor = System.Drawing.Color.White;
            this.txtInside.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInside.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInside.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtInside.Location = new System.Drawing.Point(3, 6);
            this.txtInside.Mask = "0000-00-00";
            this.txtInside.Name = "txtInside";
            this.txtInside.Size = new System.Drawing.Size(159, 16);
            this.txtInside.TabIndex = 3;
            this.txtInside.ValidatingType = typeof(System.DateTime);
            // 
            // PnlImageBG
            // 
            this.PnlImageBG.BackColor = System.Drawing.Color.White;
            this.PnlImageBG.BackgroundImage = RDIFramework.Controls.Properties.Resources.Input;
            this.PnlImageBG.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlImageBG.Location = new System.Drawing.Point(0, 0);
            this.PnlImageBG.Name = "PnlImageBG";
            this.PnlImageBG.Size = new System.Drawing.Size(160, 3);
            this.PnlImageBG.TabIndex = 1;
            // 
            // UcMaskTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlBorder);
            this.Name = "UcMaskTextBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(164, 27);
            this.PnlBorder.ResumeLayout(false);
            this.PnlWhiteBG.ResumeLayout(false);
            this.PnlWhiteBG.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBorder;
        private System.Windows.Forms.Panel PnlWhiteBG;
        private System.Windows.Forms.Panel PnlImageBG;
        public System.Windows.Forms.MaskedTextBox txtInside;
    }
}
