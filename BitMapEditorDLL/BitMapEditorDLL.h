// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the BITMAPEDITORDLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// BITMAPEDITORDLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef BITMAPEDITORDLL_EXPORTS
#define BITMAPEDITORDLL_API __declspec(dllexport)
#else
#define BITMAPEDITORDLL_API __declspec(dllimport)
#endif

// This class is exported from the BitMapEditorDLL.dll
class BITMAPEDITORDLL_API CBitMapEditorDLL {
public:
	CBitMapEditorDLL(void);
	// TODO: add your methods here.
};

extern BITMAPEDITORDLL_API int nBitMapEditorDLL;

BITMAPEDITORDLL_API int fnBitMapEditorDLL(void);
