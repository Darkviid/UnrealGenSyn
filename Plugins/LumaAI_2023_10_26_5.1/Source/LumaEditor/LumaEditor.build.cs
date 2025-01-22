// # Copyright 2023 Luma AI
// # Includes adapted sources from TBRaymarcherPlugin https://github.com/tommybazar/TBRaymarcherPlugin by Tomas Bartipan and Technical University of Munich (MIT)

using UnrealBuildTool;

public class LumaEditor : ModuleRules
{
	public LumaEditor(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
		bUsePrecompiled = true;
		//PrecompileForTargets = PrecompileTargetsType.Any;

		AddEngineThirdPartyPrivateStaticDependencies(Target, "zlib");

		CppStandard = CppStandardVersion.Cpp17;

		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"UnrealEd", 
				"AssetTools",
				"Kismet",
				"Core",
				"RenderCore",
				"RHI",
				"AssetRegistry",
				"zlib",
			}
		);

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore", 
				"LumaRuntime", 
				"Niagara",
			}
		);
	}
}
