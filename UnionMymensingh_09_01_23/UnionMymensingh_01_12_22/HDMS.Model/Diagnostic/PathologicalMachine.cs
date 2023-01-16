using System;


namespace HDMS.Model {
public class PathologicalMachine{
public int Id { get; set; }
public string MachineName { get; set; }
public string  ApplicableFor { get; set; }
public int ReportTypeId { get; set; }  // This will be ReportTypeId
public string MachineShortName { get; set; }
public int Priority { get; set; }
}
}