// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class LumaRuntime: ModuleRules
{
	public LumaRuntime(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        CppStandard = CppStandardVersion.Cpp17;
        bUsePrecompiled = true;
        //PrecompileForTargets = PrecompileTargetsType.Any;

        PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{ 
                "Core",
                "RenderCore",
                "Engine",
                "RHI",
                "AssetRegistry",
				"HeadMountedDisplay",
				"InputCore", "Niagara",
				// ... add other public dependencies that you statically link with here ...
			}
            );
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
                "SlateCore",
                "UMG",
                "Niagara"
				// ... add private dependencies that you statically link with here ...	
			}
            );
		
		if (Target.Type == TargetType.Editor) // Is UBT building for Editor ?
		{
			PrivateDependencyModuleNames.Add("UnrealEd");
		}

		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);
	}
}
