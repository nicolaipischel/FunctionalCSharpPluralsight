using System.Collections.Immutable;

namespace Models.Types.Products;

public class AssemblyInstruction
{
    private ImmutableList<InstructionSegment> Segments { get; }

    public AssemblyInstruction() : this(ImmutableList<InstructionSegment>.Empty) { }

    public AssemblyInstruction(IEnumerable<InstructionSegment> segements)
        : this(segements.ToImmutableList()) { }
    private AssemblyInstruction(ImmutableList<InstructionSegment> segments) =>
        Segments = segments;

    public AssemblyInstruction Append(IEnumerable<InstructionSegment> segments) =>
        new(this.Segments.AddRange(segments));

    public AssemblyInstruction Append(params InstructionSegment[] segments) =>
        segments.Length == 0
            ? this
            : segments.Length == 1
                ? new(this.Segments.Add(segments[0]))
                : new(this.Segments.AddRange(segments));
}
