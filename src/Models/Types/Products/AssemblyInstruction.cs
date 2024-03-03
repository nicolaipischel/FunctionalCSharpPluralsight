using System.Collections.Immutable;

namespace Models.Types.Products;

public class AssemblyInstruction
{
    private ImmutableList<InstructionSegment> Segments { get; }

    public AssemblyInstruction() : this(ImmutableList<InstructionSegment>.Empty) { }

    private AssemblyInstruction(ImmutableList<InstructionSegment> segments) =>
        Segments = segments;

    public AssemblyInstruction Append(InstructionSegment segment) =>
        new(this.Segments.Add(segment));
}
