using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Events;

using com.VehicleAnalyse.DataModel;
using AppUtil;
using com.VehicleAnalyse.Main.ViewModels;

namespace com.VehicleAnalyse.Main.Framework
{
    public class AnalyseRecordEvent : CompositePresentationEvent<AnalyseRecord> { }

    public class AnalyseRecordsByFileEvent : CompositePresentationEvent<Tuple<string, AnalyseRecord[]>> { }

    public class AnalyseMessageEvent : CompositePresentationEvent<Tuple<uint, string>> { }
        
    public class UserLoginEvent : CompositePresentationEvent<LoginToken>
    {

    }
    public class SearchFinishedEvent : CompositePresentationEvent<Tuple<List<AnalyseRecord>,long,string>> { }
    public class SearchSwitchFinishedEvent : CompositePresentationEvent<Tuple<List<AnalyseRecord>, long,string>> { }

    public class CompareSearchFinishedEvent : CompositePresentationEvent<Tuple<List<AnalyseRecord>, long,string>> { }

    public class OutputWindowSwitch : CompositePresentationEvent<bool>
    {

    }
    public class SelectedTaskChangedEvent : CompositePresentationEvent<AnalyseTask> { }

    public class TaskAddedEvent : CompositePresentationEvent<AnalyseTask> { }

    public class TaskRemovedEvent : CompositePresentationEvent<AnalyseTask> { }

    public class TaskModifiedEvent : CompositePresentationEvent<List<AnalyseTask>> { }

    public class TaskStatusChangeEvent : CompositePresentationEvent<TaskProgressStatusInfo> { }

    public class ViewResultsEvent : CompositePresentationEvent<AnalyseTask> { }

    public class ViewFailedResultsEvent : CompositePresentationEvent<AnalyseTask> { }

    public class NewSearchEvent : CompositePresentationEvent<SearchPara>{}

    public class NewCompareSearchEvent : CompositePresentationEvent<SearchPara> { }

    public class TaskStatisticUpdateEvent : CompositePresentationEvent<Tuple<int, int>> { }

}
