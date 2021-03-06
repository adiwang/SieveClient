﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveClient
{
    class TextRes
    {
        public static Dictionary<string, string> text = new Dictionary<string, string>()
        {
            {"ConnectCasdErr", "连接casd: {0}:{1} 失败"},
            {"ConnectCtrlErr", "连接控制器: {0}:{1} 失败"},
            {"WaitBatchClassifyBegin", "等待批次分级开始"},
            {"WaitSingleClassifyBegin", "等待单次分级开始"},
            {"InClassifying", "分级中，请稍候"},
            {"ValidatePosErr", "摆放位置不正确， 请重新摆放"},
            {"SingleClassifyEnd", "单次分级结束"},
            {"BatchClassifyEnd", "批次分级结束"},
            {"SingleClassResult", "样本{0}: , 等级: {1}\r\n"},
            {"StatisticsClassResult", "等级: {0}, 个数: {1}, 样本比例: {2:P}\r\n"},
            {"WaitBatchLearnBegin", "等待批次学习开始"},
            {"WaitSingleLearnBegin", "等待单次学习开始"},
            {"InLearning", "学习中，请稍候"},
            {"SingleLearnEnd", "单次学习结束"},
            {"BatchLearnEnd", "批次学习结束"},
            {"SingleLearnResult", "样本{0}: , 等级: {1}\r\n"},
            {"StatisticsLearnResult", "等级: {0}, 学习数量: {1}, 样本比例: {2:P}\r\n"},
            {"EmptyLearnGradeErr", "请选择样本等级"},
            {"InvalidLearnGradeErr", "样本等级输入有误，请检查样本等级"},
        };
    }
}
