using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class AllTable
{
    public string Script { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ObjectId { get; set; }

    public int? PrincipalId { get; set; }

    public int SchemaId { get; set; }

    public int ParentObjectId { get; set; }

    public string? Type { get; set; }

    public string? TypeDesc { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifyDate { get; set; }

    public bool IsMsShipped { get; set; }

    public bool IsPublished { get; set; }

    public bool IsSchemaPublished { get; set; }

    public int LobDataSpaceId { get; set; }

    public int? FilestreamDataSpaceId { get; set; }

    public int MaxColumnIdUsed { get; set; }

    public bool LockOnBulkLoad { get; set; }

    public bool? UsesAnsiNulls { get; set; }

    public bool? IsReplicated { get; set; }

    public bool? HasReplicationFilter { get; set; }

    public bool? IsMergePublished { get; set; }

    public bool? IsSyncTranSubscribed { get; set; }

    public bool HasUncheckedAssemblyData { get; set; }

    public int? TextInRowLimit { get; set; }

    public bool? LargeValueTypesOutOfRow { get; set; }

    public bool? IsTrackedByCdc { get; set; }

    public byte? LockEscalation { get; set; }

    public string? LockEscalationDesc { get; set; }

    public bool? IsFiletable { get; set; }

    public bool? IsMemoryOptimized { get; set; }

    public byte? Durability { get; set; }

    public string? DurabilityDesc { get; set; }

    public byte? TemporalType { get; set; }

    public string? TemporalTypeDesc { get; set; }

    public int? HistoryTableId { get; set; }

    public bool? IsRemoteDataArchiveEnabled { get; set; }

    public bool IsExternal { get; set; }

    public int? HistoryRetentionPeriod { get; set; }

    public int? HistoryRetentionPeriodUnit { get; set; }

    public string? HistoryRetentionPeriodUnitDesc { get; set; }

    public bool? IsNode { get; set; }

    public bool? IsEdge { get; set; }

    public int? DataRetentionPeriod { get; set; }

    public int? DataRetentionPeriodUnit { get; set; }

    public string? DataRetentionPeriodUnitDesc { get; set; }

    public byte? LedgerType { get; set; }

    public string? LedgerTypeDesc { get; set; }

    public int? LedgerViewId { get; set; }

    public bool? IsDroppedLedgerTable { get; set; }
}
