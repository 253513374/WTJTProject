﻿namespace ScanCode.Model.ResponseModel
{
    public class PrizeResult : TResult
    {
        /// <summary>
        /// 奖品编号。
        /// </summary>
        public string PrizeNumber { get; set; }//奖品编号

        /// <summary>
        /// 奖品名称
        /// </summary>
        public string Name { get; set; }//奖品名称

        /// <summary>
        /// 奖品描述
        /// </summary>
        public string Description { get; set; }//奖品描述

        /// <summary>
        /// 奖品图片
        /// </summary>
        public string ImageUrl { get; set; }//奖品图片

        public double Probability { get; set; }
    }
}