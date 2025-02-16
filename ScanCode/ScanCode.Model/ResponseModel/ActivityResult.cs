﻿using ScanCode.Model.Enum;
using System;
using System.Collections.Generic;

namespace ScanCode.Model.ResponseModel
{
    public class ActivityResult : TResult
    {
        public ActivityResult() : base()
        {
            Prizes = new List<PrizeResult>();
            IsSuccess = false;
        }

        /// <summary>
        /// 活动编号
        /// </summary>
        public string ActivityNumber { get; set; }

        /// <summary>
        /// 查询状态
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 查询信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 活动状态
        /// </summary>
        public ActivityStatus Status { get; set; }

        /// <summary>
        /// 活动启用或者禁用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 活动图片
        /// </summary>
        public string ActivityImage { get; set; }

        /// <summary>
        /// 参与活动的奖品列表
        /// </summary>
        public List<PrizeResult> Prizes { get; set; }
    }
}