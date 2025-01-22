#pragma once
 
//Use for plugin

#include "CoreMinimal.h"
// UE4 #include "ModuleManager.h" in UE5
#include "Modules/ModuleManager.h"


class FAnimNodeModule : public IModuleInterface
{
public:

	// IModuleInterface implementation 
	virtual void StartupModule() override;
	virtual void ShutdownModule() override;
};



//Use for module
//#include "ModuleManager.h"