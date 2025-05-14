#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2>
struct InterfaceActionInvoker2
{
	typedef void (*Action)(void*, T1, T2, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3, typename T4>
struct InterfaceActionInvoker4
{
	typedef void (*Action)(void*, T1, T2, T3, T4, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3, T4 p4)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, p4, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename R, typename T1>
struct InterfaceFuncInvoker1
{
	typedef R (*Func)(void*, T1, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};

struct Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA;
struct Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710;
struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83;
struct IEqualityComparer_1_tAE94C8F24AD5B94D4EE85CA9FC59E3409D41CAF7;
struct KeyCollection_tE66790F09E854C19C7F612BEAD203AE626E90A36;
struct KeyCollection_t2EDD317F5771E575ACB63527B5AFB71291040342;
struct ValueCollection_tC9D91E8A3198E40EA339059703AB10DFC9F5CC2E;
struct ValueCollection_t238D0D2427C6B841A01F522A41540165A2C4AE76;
struct EntryU5BU5D_t233BB24ED01E2D8D65B0651D54B8E3AD125CAF96;
struct EntryU5BU5D_t1AF33AD0B7330843448956EC4277517081658AE7;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;
struct ATConsentDismissListener_tDD5DD6817C2D98082903F1A2098FEE8AB987B0EC;
struct ATConst_tC4379944A54BD1D08DADD87FB3878EC04620C8E7;
struct ATDownloadAdListener_tB7F77A496620D25C9B5B5DCC8724FB3F3D65EB40;
struct ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B;
struct ATGetAreaListener_tFE83035181F5B5C2374F40A83BE1566DAB64E9AE;
struct ATGetUserLocationListener_t3CEF39FAD9648842EDE9192DE42980E2AB798201;
struct ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817;
struct ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509;
struct ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB;
struct ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB;
struct ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D;
struct ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C;
struct ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC;
struct ATNativeBannerAdListener_t19CB9EFD2488B37B617C102D5140C4DC0E6D23A3;
struct ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1;
struct ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A;
struct ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A;
struct ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2;
struct ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36;
struct ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97;
struct ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6;
struct ATSDKInitListener_t792D34E04FD6176B6885B70F08B8272793F7BB1F;
struct ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D;
struct ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C;
struct ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69;
struct IATDownloadClient_tE915DC3A98BA33AE641D7D773A373ECF33EBAEDC;
struct IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C;
struct IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C;
struct IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294;
struct IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9;
struct IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B;
struct IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A;
struct String_t;
struct StringBuilder_t;

IL2CPP_EXTERN_C RuntimeClass* ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATDownloadClient_tE915DC3A98BA33AE641D7D773A373ECF33EBAEDC_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* StringBuilder_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral03B000D2C4DAFF596116BD3AC596F41D96CFF5B9;
IL2CPP_EXTERN_C String_t* _stringLiteral062DB096C728515E033CF8C48A1C1F0B9A79384B;
IL2CPP_EXTERN_C String_t* _stringLiteral0BABBCE95BCD478A1457643796BE96B9ACA4E6C2;
IL2CPP_EXTERN_C String_t* _stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A;
IL2CPP_EXTERN_C String_t* _stringLiteral0DA44B4B2555A4BCF3589D4EC74EB1AB1ACD9912;
IL2CPP_EXTERN_C String_t* _stringLiteral1084E0508EC132638288C6F0A8F166242775D100;
IL2CPP_EXTERN_C String_t* _stringLiteral10CFCF3EBD4D77E7A54DFD0926B0796496169AB9;
IL2CPP_EXTERN_C String_t* _stringLiteral10D904031D0D73164858E9561BEBF8188F164AF6;
IL2CPP_EXTERN_C String_t* _stringLiteral1388D53684B0996B3FF27203D1547660E4D82509;
IL2CPP_EXTERN_C String_t* _stringLiteral16AE29D4982527C4C7A6AF3EB4314E66EAD38294;
IL2CPP_EXTERN_C String_t* _stringLiteral170AD99AD2A9FB6605C713D5E03E562C7D968B69;
IL2CPP_EXTERN_C String_t* _stringLiteral171032605001E1912A8A0600431BF07A1726537F;
IL2CPP_EXTERN_C String_t* _stringLiteral1745ECCF09CB581FB30F96360D0D0E8B3E0AD134;
IL2CPP_EXTERN_C String_t* _stringLiteral19A4DD21BBFD4F7063C65CBD5B8DEB0688B58B10;
IL2CPP_EXTERN_C String_t* _stringLiteral1D1EFCF52A4E0FA49E30A3DE65058928ACB5EF13;
IL2CPP_EXTERN_C String_t* _stringLiteral1E311C21F2D76CF060E680B7BEFF2383C44D3F9F;
IL2CPP_EXTERN_C String_t* _stringLiteral2512497A38103E878C0A6145651B419DEE131154;
IL2CPP_EXTERN_C String_t* _stringLiteral25705477E232DDE539315FA572A0CE775D407106;
IL2CPP_EXTERN_C String_t* _stringLiteral292BD63800E4D7AB03958C97F752AA04D34A681B;
IL2CPP_EXTERN_C String_t* _stringLiteral2E52B4BC35C1F9068E8AD23DC9937D65194A5135;
IL2CPP_EXTERN_C String_t* _stringLiteral2FCC894C8E31955BBEE1DA8D542825C6EFA4CC19;
IL2CPP_EXTERN_C String_t* _stringLiteral33018FA8926405B4E44C0D1902B3435E469A55E2;
IL2CPP_EXTERN_C String_t* _stringLiteral33F6758AC1777DAA0016096F040CBC13B8AB090F;
IL2CPP_EXTERN_C String_t* _stringLiteral3A0638EF431254803510AEEF4E30E0DCB0C2E12D;
IL2CPP_EXTERN_C String_t* _stringLiteral46EBAC5E8BDA7E4F7044E37E0C769312169C651B;
IL2CPP_EXTERN_C String_t* _stringLiteral483DFA9A614472DBFD4B58265DDE1C943D92F756;
IL2CPP_EXTERN_C String_t* _stringLiteral486C5E022B623208CEC796B9BCD2F72E31E8A072;
IL2CPP_EXTERN_C String_t* _stringLiteral4C9820D0000A8721F54710F1ABFB2EDBFC71FDE8;
IL2CPP_EXTERN_C String_t* _stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30;
IL2CPP_EXTERN_C String_t* _stringLiteral6464580B4BA3FBA5EE5A3A1A31C35F8B2BB42CB9;
IL2CPP_EXTERN_C String_t* _stringLiteral64ECDAF6849D3AB5BFABD37685135C6123A23CC3;
IL2CPP_EXTERN_C String_t* _stringLiteral6697CDCB0762971428BEAB2CC086B115C9E38187;
IL2CPP_EXTERN_C String_t* _stringLiteral6CC49087803A7B2C8D0F9B2626880FF8EC4FF94C;
IL2CPP_EXTERN_C String_t* _stringLiteral71C17B3684796D88DD17328DF65F347A856EAF31;
IL2CPP_EXTERN_C String_t* _stringLiteral778F4B6769BD76BEA1B6F935EF09DAE5B686E017;
IL2CPP_EXTERN_C String_t* _stringLiteral7AFF5DCE6B762488699DFA749CC45116752C6045;
IL2CPP_EXTERN_C String_t* _stringLiteral7DD4F702FB1B016670C03544EB428F980A55531C;
IL2CPP_EXTERN_C String_t* _stringLiteral83A97723F7E5BDE036330459FB667402C7C32740;
IL2CPP_EXTERN_C String_t* _stringLiteral8769D5429AA71436D34F062199813C43C7D11E01;
IL2CPP_EXTERN_C String_t* _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D;
IL2CPP_EXTERN_C String_t* _stringLiteral9042595A1005F3694F667150D68011E6E1B221D7;
IL2CPP_EXTERN_C String_t* _stringLiteral90777CC080B8210DFA568244B6C673ACA06D9BFF;
IL2CPP_EXTERN_C String_t* _stringLiteral988090910866A3AC43E431323DD6916C60B1A59A;
IL2CPP_EXTERN_C String_t* _stringLiteralA223E6F0C54D77B42B95E26C1F074DA464E2049C;
IL2CPP_EXTERN_C String_t* _stringLiteralA56563187CE402C2D214D1D438FAEFE383069121;
IL2CPP_EXTERN_C String_t* _stringLiteralA582AFCA1811C5E0A07C5B63E7A046DFA7087D1A;
IL2CPP_EXTERN_C String_t* _stringLiteralA5B0B11BB35DDF1357AB0D80F47D1B74FAA4E9A8;
IL2CPP_EXTERN_C String_t* _stringLiteralA76A1FBB5BDCCBC5DBCEDB47C87027870724AC3E;
IL2CPP_EXTERN_C String_t* _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D;
IL2CPP_EXTERN_C String_t* _stringLiteralB714933B91F72FB57380135D2B50660975351E49;
IL2CPP_EXTERN_C String_t* _stringLiteralBC0048E68AAA6E10064F62D278CB090D1AAE69DF;
IL2CPP_EXTERN_C String_t* _stringLiteralBC0CFC91159B68CDB00561EE3B792C9679F86738;
IL2CPP_EXTERN_C String_t* _stringLiteralBFB810260B3D8BC7FC286E1DFC7D03ED191A782B;
IL2CPP_EXTERN_C String_t* _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB;
IL2CPP_EXTERN_C String_t* _stringLiteralC2174A5652A092BA4EA81CC88E05A4CF11987070;
IL2CPP_EXTERN_C String_t* _stringLiteralC5AEAC59DFAF8098FFEBA846B955A932F758E831;
IL2CPP_EXTERN_C String_t* _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677;
IL2CPP_EXTERN_C String_t* _stringLiteralC7B4D926EF9532A71B25AEC040A33D52C926425F;
IL2CPP_EXTERN_C String_t* _stringLiteralCB95AC6F5DAF4F3EB9438A7F55847FF126519704;
IL2CPP_EXTERN_C String_t* _stringLiteralCC1F7052057A1EC518E41F548AA4C5A4BA47C59D;
IL2CPP_EXTERN_C String_t* _stringLiteralDA29C31BF1A1235E83B36C818C313368D6188CA1;
IL2CPP_EXTERN_C String_t* _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709;
IL2CPP_EXTERN_C String_t* _stringLiteralDE6D13D8B5CAB7B6CF611C5B25BC71DE7AA04FD5;
IL2CPP_EXTERN_C String_t* _stringLiteralE0560976B58269705E291202AB17A7D7F1543FA4;
IL2CPP_EXTERN_C String_t* _stringLiteralE652D195EED39893D696733B289E29130B7D0A52;
IL2CPP_EXTERN_C String_t* _stringLiteralEDCC39ACE1BE3A6CCC4D73DEDA17B26E795EF1D3;
IL2CPP_EXTERN_C String_t* _stringLiteralEE88DB00CE4B2E2DC6AB5DCD8BBEB39289B25168;
IL2CPP_EXTERN_C String_t* _stringLiteralEF042A4C30146DF9FD9D245912DCA96150741EF5;
IL2CPP_EXTERN_C String_t* _stringLiteralF18D9351ADB98D1E281ABDAE06CD78D7EA630828;
IL2CPP_EXTERN_C String_t* _stringLiteralF455F86FAE600437E02E61A410A984183EB8EC54;
IL2CPP_EXTERN_C String_t* _stringLiteralFA590547E6EFCCA8DA15CB0A84030B57AFDE8FA4;
IL2CPP_EXTERN_C String_t* _stringLiteralFCEC1331B0ED56283A557BB3EE79406A80D474CC;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5_RuntimeMethod_var;

struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710  : public RuntimeObject
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets;
	EntryU5BU5D_t233BB24ED01E2D8D65B0651D54B8E3AD125CAF96* ____entries;
	int32_t ____count;
	int32_t ____freeList;
	int32_t ____freeCount;
	int32_t ____version;
	RuntimeObject* ____comparer;
	KeyCollection_tE66790F09E854C19C7F612BEAD203AE626E90A36* ____keys;
	ValueCollection_tC9D91E8A3198E40EA339059703AB10DFC9F5CC2E* ____values;
	RuntimeObject* ____syncRoot;
};
struct Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83  : public RuntimeObject
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ____buckets;
	EntryU5BU5D_t1AF33AD0B7330843448956EC4277517081658AE7* ____entries;
	int32_t ____count;
	int32_t ____freeList;
	int32_t ____freeCount;
	int32_t ____version;
	RuntimeObject* ____comparer;
	KeyCollection_t2EDD317F5771E575ACB63527B5AFB71291040342* ____keys;
	ValueCollection_t238D0D2427C6B841A01F522A41540165A2C4AE76* ____values;
	RuntimeObject* ____syncRoot;
};
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA  : public RuntimeObject
{
};
struct ATConst_tC4379944A54BD1D08DADD87FB3878EC04620C8E7  : public RuntimeObject
{
};
struct ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509  : public RuntimeObject
{
};
struct ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3  : public RuntimeObject
{
};
struct ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D  : public RuntimeObject
{
};
struct ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C  : public RuntimeObject
{
	ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* ___config;
	String_t* ___parentKey;
	String_t* ___appIconKey;
	String_t* ___mainImageKey;
	String_t* ___titleKey;
	String_t* ___descKey;
	String_t* ___adLogoKey;
	String_t* ___ctaButtonKey;
	String_t* ___dislikeButtonKey;
	String_t* ___elementsKey;
};
struct ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1  : public RuntimeObject
{
};
struct ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A  : public RuntimeObject
{
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___parentProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___appIconProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___mainImageProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___titleProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___descProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___adLogoProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___ctaButtonProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___dislikeButtonProperty;
	ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* ___elementsProperty;
};
struct ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A  : public RuntimeObject
{
	int32_t ___x;
	int32_t ___y;
	int32_t ___width;
	int32_t ___height;
	bool ___usesPixel;
	String_t* ___backgroundColor;
	String_t* ___textColor;
	int32_t ___textSize;
	bool ___isCustomClick;
};
struct ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2  : public RuntimeObject
{
	int32_t ___x;
	int32_t ___y;
	int32_t ___width;
	int32_t ___height;
	bool ___usesPixel;
};
struct ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6  : public RuntimeObject
{
};
struct ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D  : public RuntimeObject
{
	int32_t ___width;
	int32_t ___height;
	bool ___usesPixel;
};
struct ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C  : public RuntimeObject
{
	RuntimeObject* ___client;
};
struct ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct StringBuilder_t  : public RuntimeObject
{
	CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB* ___m_ChunkChars;
	StringBuilder_t* ___m_ChunkPrevious;
	int32_t ___m_ChunkLength;
	int32_t ___m_ChunkOffset;
	int32_t ___m_MaxCapacity;
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	Il2CppChar ___m_value;
};
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D112_t338F22B6F3CC67FDBAE2DB73218458D355AA2089 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D112_t338F22B6F3CC67FDBAE2DB73218458D355AA2089__padding[112];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D11648_t6ACC8B88CF5CE61A6134E8742B2F38FAF6D37A41 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D11648_t6ACC8B88CF5CE61A6134E8742B2F38FAF6D37A41__padding[11648];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F__padding[12];
	};
};
#pragma pack(pop, tp)
#pragma pack(push, tp, 1)
struct __StaticArrayInitTypeSizeU3D6921_t176A28D6487D22CD1418AB0F8C20723DADEE3F1A 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D6921_t176A28D6487D22CD1418AB0F8C20723DADEE3F1A__padding[6921];
	};
};
#pragma pack(pop, tp)
struct U3CPrivateImplementationDetailsU3E_t0F5473E849A5A5185A9F4C5246F0C32816C49FCA_StaticFields
{
	__StaticArrayInitTypeSizeU3D6921_t176A28D6487D22CD1418AB0F8C20723DADEE3F1A ___0525EF0BED897A935DD10B97F94FF3CEF3CFFA920B378CFE61EC1DC735DA8E7B;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___59B7E757844D3BF9299877BD1C17451611BFBAB493374D6B18D973FDE534151A;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___5B979F69B96A61586A09DD4ED26F20534C629B08732AE32FA34B6F8A0049ACDD;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___7FCA397EF25DB53B2C58A05F9BBFA4E8E0685FDBC8AAF39536123447056895C0;
	__StaticArrayInitTypeSizeU3D11648_t6ACC8B88CF5CE61A6134E8742B2F38FAF6D37A41 ___A369663985DFB0211BB2F8E041AF877B602C65E58B4BF053B3BAAE8EA79F4902;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___B257E85A5D3CAB5E738D5A0FD1A7AE96624BFE92CB7915726CBBE1518C3225CF;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___B7A918F6F138CA8137025633559198B529D28CCEC5A51B005376CC69A5B83D85;
	__StaticArrayInitTypeSizeU3D112_t338F22B6F3CC67FDBAE2DB73218458D355AA2089 ___C84227140A8A7787B30DFF8BD5693C19AA5A430C4E89FFD0256D7F77B3FEAD82;
	__StaticArrayInitTypeSizeU3D12_t1BDD2193C3F925556BCD5FF35C0AC52DDB0CAB8F ___FC03ECB1D62767A5B31230F548FA4D4C02F01E3DA8CA1FC66C7C332EA16BF206;
};
struct ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_StaticFields
{
	ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* ___instance;
};
struct ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_StaticFields
{
	ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* ___instance;
};
struct ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields
{
	String_t* ___kATInterstitialAdLoadingExtraInterstitialAdSize;
	String_t* ___kATInterstitialAdLoadingExtraInterstitialAdSizeStruct;
	String_t* ___kATInterstitialAdSizeUsesPixelFlagKey;
};
struct ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_StaticFields
{
	ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* ___instance;
};
struct ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3_StaticFields
{
	bool ___isDebug;
};
struct ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_StaticFields
{
	ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* ___instance;
};
struct ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields
{
	String_t* ___kATNativeAdLoadingExtraNativeAdSizeStruct;
	String_t* ___kATNativeAdLoadingExtraNativeAdSize;
	String_t* ___kATNativeAdSizeUsesPixelFlagKey;
};
struct ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_StaticFields
{
	ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* ___instance;
};
struct ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields
{
	String_t* ___kATNativeBannerAdShowingExtraBackgroundColor;
	String_t* ___kATNativeBannerAdShowingExtraAutorefreshInterval;
	String_t* ___kATNativeBannerAdShowingExtraHideCloseButtonFlag;
	String_t* ___kATNativeBannerAdShowingExtraCTAButtonBackgroundColor;
	String_t* ___kATNativeBannerAdShowingExtraCTATextColor;
	String_t* ___kATNativeBannerAdShowingExtraCTATextFont;
	String_t* ___kATNativeBannerAdShowingExtraTitleColor;
	String_t* ___kATNativeBannerAdShowingExtraTitleFont;
	String_t* ___kATNativeBannerAdShowingExtraTextColor;
	String_t* ___kATNativeBannerAdShowingExtraTextFont;
	String_t* ___kATNativeBannerAdShowingExtraAdvertiserTextFont;
	String_t* ___kATNativeBannerAdShowingExtraAdvertiserTextColor;
};
struct ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_StaticFields
{
	ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* ___instance;
};
struct ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_StaticFields
{
	ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* ___instance;
};
struct ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields
{
	int32_t ___kATUserLocationUnknown;
	int32_t ___kATUserLocationInEU;
	int32_t ___kATUserLocationOutOfEU;
	int32_t ___PERSONALIZED;
	int32_t ___NONPERSONALIZED;
	int32_t ___UNKNOWN;
	int32_t ___AREA_GLOBAL;
	int32_t ___AREA_CHINESE_MAINLAND;
	String_t* ___OS_VERSION_NAME;
	String_t* ___OS_VERSION_CODE;
	String_t* ___APP_PACKAGE_NAME;
	String_t* ___APP_VERSION_NAME;
	String_t* ___APP_VERSION_CODE;
	String_t* ___BRAND;
	String_t* ___MODEL;
	String_t* ___DEVICE_SCREEN_SIZE;
	String_t* ___MNC;
	String_t* ___MCC;
	String_t* ___LANGUAGE;
	String_t* ___TIMEZONE;
	String_t* ___USER_AGENT;
	String_t* ___ORIENTATION;
	String_t* ___NETWORK_TYPE;
	String_t* ___INSTALLER;
	String_t* ___ANDROID_ID;
	String_t* ___GAID;
	String_t* ___MAC;
	String_t* ___IMEI;
	String_t* ___OAID;
	String_t* ___IDFA;
	String_t* ___IDFV;
	RuntimeObject* ___client;
};
struct ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_StaticFields
{
	ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* ___instance;
};
struct ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_StaticFields
{
	String_t* ___kATSplashAdClickConfirmStatus;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248  : public RuntimeArray
{
	ALIGN_FIELD (8) String_t* m_Items[1];

	inline String_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline String_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, String_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline String_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline String_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, String_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool Dictionary_2_ContainsKey_m703047C213F7AB55C9DC346596287773A1F670CD_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, RuntimeObject* ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Dictionary_2_get_Item_m4AAAECBE902A211BF2126E6AFA280AEF73A3E0D6_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, RuntimeObject* ___0_key, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2_Add_m93FFFABE8FCE7FA9793F0915E2A8842C7CD0C0C1_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Dictionary_2__ctor_m5B32FBC624618211EB461D59CFBB10E987FD1329_gshared (Dictionary_2_t14FE4A752A83D53771C584E4C8D14E01F2AFD7BA* __this, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATDownloadManager_GetATDownloadClient_mDFF4044D1AB6059A6E37159DDE6521B2762AC946 (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildDownloadClient_m01BEAA96DE6F67DE37B14B442038A84392089C0A (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATDownloadManager__ctor_m64D1D4CBF4F7B76A6B228DDC40003012A4C75DD6 (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATInterstitialAd_GetATInterstitialAdClient_m62231E37E232FC8667C708DDB6776925B72A92CA (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, const RuntimeMethod* method) ;
inline bool Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* __this, String_t* ___0_key, const RuntimeMethod* method)
{
	return ((  bool (*) (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710*, String_t*, const RuntimeMethod*))Dictionary_2_ContainsKey_m703047C213F7AB55C9DC346596287773A1F670CD_gshared)(__this, ___0_key, method);
}
inline RuntimeObject* Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5 (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* __this, String_t* ___0_key, const RuntimeMethod* method)
{
	return ((  RuntimeObject* (*) (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710*, String_t*, const RuntimeMethod*))Dictionary_2_get_Item_m4AAAECBE902A211BF2126E6AFA280AEF73A3E0D6_gshared)(__this, ___0_key, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5 (int32_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B (String_t* ___0_str0, String_t* ___1_str1, String_t* ___2_str2, const RuntimeMethod* method) ;
inline void Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443 (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* __this, String_t* ___0_key, RuntimeObject* ___1_value, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710*, String_t*, RuntimeObject*, const RuntimeMethod*))Dictionary_2_Add_m93FFFABE8FCE7FA9793F0915E2A8842C7CD0C0C1_gshared)(__this, ___0_key, ___1_value, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336 (RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
inline void Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* __this, const RuntimeMethod* method)
{
	((  void (*) (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*, const RuntimeMethod*))Dictionary_2__ctor_m5B32FBC624618211EB461D59CFBB10E987FD1329_gshared)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildInterstitialAdClient_m6014DFF80BD26B751FAF92AE1B759DB7A5B7908D (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd__ctor_m9874DE86B16F638ABC4E130FC010823146557BC7 (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATInterstitialAutoAd_GetATInterstitialAdClient_m4651472CE4648AB839281D7CCD53601284F8F769 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Concat_m9E3155FB84015C823606188F53B47CB44C444991 (String_t* ___0_str0, String_t* ___1_str1, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB (RuntimeObject* ___0_message, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd__ctor_m72B186CF744A756B6942B0AC716B99B737E2F5F9 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATNativeAd_GetATNativeAdClient_m6DECED9819AD205496269D71232AE4335B893190 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildNativeAdClient_m77A89B3892F66666F279433A4BFD5841B174AA8B (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd__ctor_m87494718B200DC48F14CEA528D1E59F8C50D2487 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D (StringBuilder_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR StringBuilder_t* StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D (StringBuilder_t* __this, String_t* ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA (RuntimeObject* ___0_obj, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool String_EndsWith_mCD3754F5401E19CE7821CD398986E4EAA6AD87DC (String_t* __this, String_t* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE (String_t* __this, int32_t ___0_startIndex, int32_t ___1_length, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATNativeBannerAd_GetATNativeBannerAdClient_mC1C8967325B4670DCC85ACFD3E9E108439BA1155 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildNativeBannerAdClient_m2AE4C998D94CD271CCFD1F8443E9F8C9B79DAEBC (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd__ctor_m2B334A6D47425C7B2F8171950299AA57C02CB598 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATRewardedAutoVideo_GetATRewardedClient_mDF7F88190674E801D86A79F892FD238E10F07566 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildRewardedVideoAdClient_m6DE6B8A9057F9081333F5BC2E3A3A2DA18958BBB (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo__ctor_m9777C43E623BB3F67D3A771999635555138DED42 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATRewardedVideo_GetATRewardedClient_m6AD500ECAA75AA0D99E6A59E9B530614EC8FE1D2 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo__ctor_mC1740A24437B415D0FE589D663F3F0874F5CDADD (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ATLogger_set_IsDebug_m56AA630766065D05050ECC2F81BB817DE9E7A4B5_inline (bool ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildSDKAPIClient_m5E785FB8DD24EE905E3350F0BBFBEC9BAA5F3863 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATSDKAPI_GetATSDKAPIClient_mC07322C0D667CF517304DF23CEFE5DB4B9A56FD9 (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATAdsClientFactory_BuildSplashAdClient_m6EA782E7C65779D08A095CAC1A9B30DEBFA918AC (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd__ctor_m4EE06DD2DB2C2A1F90AD7288978D2C4436DAAB97 (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___0_index, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATConst__ctor_mE178A686C9BEF0B07D1714686C4E8C343F6A6199 (ATConst_tC4379944A54BD1D08DADD87FB3878EC04620C8E7* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATDownloadManager__ctor_m64D1D4CBF4F7B76A6B228DDC40003012A4C75DD6 (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATDownloadManager_GetATDownloadClient_mDFF4044D1AB6059A6E37159DDE6521B2762AC946(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* ATDownloadManager_get_Instance_mA51B378C6DBBB4FA7AE57382402ECB0FE4FFA5EC (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var);
		ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* L_0 = ((ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_StaticFields*)il2cpp_codegen_static_fields_for(ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATDownloadManager_setListener_mDF0366C610A774BF9678ED44AC19795BE0280477 (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* __this, RuntimeObject* ___0_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATDownloadClient_tE915DC3A98BA33AE641D7D773A373ECF33EBAEDC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		RuntimeObject* L_1 = ___0_listener;
		NullCheck(L_0);
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(0, IATDownloadClient_tE915DC3A98BA33AE641D7D773A373ECF33EBAEDC_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATDownloadManager_GetATDownloadClient_mDFF4044D1AB6059A6E37159DDE6521B2762AC946 (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildDownloadClient_m01BEAA96DE6F67DE37B14B442038A84392089C0A(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATDownloadManager__cctor_mF00338E5B2C447B02E9B4B2D87759D2F0B678AD4 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B* L_0 = (ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B*)il2cpp_codegen_object_new(ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var);
		ATDownloadManager__ctor_m64D1D4CBF4F7B76A6B228DDC40003012A4C75DD6(L_0, NULL);
		((ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_StaticFields*)il2cpp_codegen_static_fields_for(ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_StaticFields*)il2cpp_codegen_static_fields_for(ATDownloadManager_t7CF62A4FEFB0854016FA6E98BA4C59AAD967272B_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAdLoadingExtra__ctor_mC61E0B6E4303EE9A1FCB8122C6163427E53888E8 (ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAdLoadingExtra__cctor_m0CB48150E440674479DFE61DA41F61A7094A8DF0 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1388D53684B0996B3FF27203D1547660E4D82509);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA223E6F0C54D77B42B95E26C1F074DA464E2049C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBC0CFC91159B68CDB00561EE3B792C9679F86738);
		s_Il2CppMethodInitialized = true;
	}
	{
		((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSize = _stringLiteralA223E6F0C54D77B42B95E26C1F074DA464E2049C;
		Il2CppCodeGenWriteBarrier((void**)(&((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSize), (void*)_stringLiteralA223E6F0C54D77B42B95E26C1F074DA464E2049C);
		((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSizeStruct = _stringLiteralBC0CFC91159B68CDB00561EE3B792C9679F86738;
		Il2CppCodeGenWriteBarrier((void**)(&((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSizeStruct), (void*)_stringLiteralBC0CFC91159B68CDB00561EE3B792C9679F86738);
		((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdSizeUsesPixelFlagKey = _stringLiteral1388D53684B0996B3FF27203D1547660E4D82509;
		Il2CppCodeGenWriteBarrier((void**)(&((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdSizeUsesPixelFlagKey), (void*)_stringLiteral1388D53684B0996B3FF27203D1547660E4D82509);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd__ctor_m9874DE86B16F638ABC4E130FC010823146557BC7 (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATInterstitialAd_GetATInterstitialAdClient_m62231E37E232FC8667C708DDB6776925B72A92CA(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* ATInterstitialAd_get_Instance_m64601EBD5729633C2F6F72031863A1AEC6187311 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var);
		ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* L_0 = ((ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd_loadInterstitialAd_m50747D0EA0ED0CECBE505E92C9A292D20AB1D6D2 (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral062DB096C728515E033CF8C48A1C1F0B9A79384B);
		s_Il2CppMethodInitialized = true;
	}
	ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* V_0 = NULL;
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_0 = ___1_pairs;
		if (!L_0)
		{
			goto IL_0075;
		}
	}
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_1 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var);
		String_t* L_2 = ((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSizeStruct;
		NullCheck(L_1);
		bool L_3;
		L_3 = Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC(L_1, L_2, Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC_RuntimeMethod_var);
		if (!L_3)
		{
			goto IL_0075;
		}
	}
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_4 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var);
		String_t* L_5 = ((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSizeStruct;
		NullCheck(L_4);
		RuntimeObject* L_6;
		L_6 = Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5(L_4, L_5, Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5_RuntimeMethod_var);
		V_0 = ((ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D*)CastclassClass((RuntimeObject*)L_6, ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D_il2cpp_TypeInfo_var));
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_7 = ___1_pairs;
		String_t* L_8 = ((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdLoadingExtraInterstitialAdSize;
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_9 = V_0;
		NullCheck(L_9);
		int32_t* L_10 = (int32_t*)(&L_9->___width);
		String_t* L_11;
		L_11 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5(L_10, NULL);
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_12 = V_0;
		NullCheck(L_12);
		int32_t* L_13 = (int32_t*)(&L_12->___height);
		String_t* L_14;
		L_14 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5(L_13, NULL);
		String_t* L_15;
		L_15 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(L_11, _stringLiteral062DB096C728515E033CF8C48A1C1F0B9A79384B, L_14, NULL);
		NullCheck(L_7);
		Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443(L_7, L_8, L_15, Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_16 = ___1_pairs;
		String_t* L_17 = ((ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAdLoadingExtra_tBDE0F8742C81BD918736554917D67DEE3884A509_il2cpp_TypeInfo_var))->___kATInterstitialAdSizeUsesPixelFlagKey;
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_18 = V_0;
		NullCheck(L_18);
		bool L_19 = L_18->___usesPixel;
		bool L_20 = L_19;
		RuntimeObject* L_21 = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &L_20);
		NullCheck(L_16);
		Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443(L_16, L_17, L_21, Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
		RuntimeObject* L_22 = __this->___client;
		String_t* L_23 = ___0_placementId;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_24 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_25;
		L_25 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_24, NULL);
		NullCheck(L_22);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_22, L_23, L_25);
		return;
	}

IL_0075:
	{
		RuntimeObject* L_26 = __this->___client;
		String_t* L_27 = ___0_placementId;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_28 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_29;
		L_29 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_28, NULL);
		NullCheck(L_26);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_26, L_27, L_29);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATInterstitialAd_hasInterstitialAdReady_mF1A3BF024681DA9E1DC51E53862A2679CFA375EA (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(2, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd_entryScenarioWithPlacementID_m91C4F2B014D83863C25F90BB6470B3B79DFB22BE (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(6, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATInterstitialAd_checkAdStatus_m2668410E8E4EABB32C12594C99CB19EF7ACB3329 (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(3, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATInterstitialAd_getValidAdCaches_mC5572111D1C5C4A46822562CB1CD3C982875F1FF (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(5, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd_showInterstitialAd_m22381E4BA100AFE9BE8473C1C183A5211347FCE8 (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*)il2cpp_codegen_object_new(Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052(L_2, Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(4, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd_showInterstitialAd_m165181255E764E6A1E923CD474EA3D8E4B39CA9C (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(4, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATInterstitialAd_GetATInterstitialAdClient_m62231E37E232FC8667C708DDB6776925B72A92CA (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildInterstitialAdClient_m6014DFF80BD26B751FAF92AE1B759DB7A5B7908D(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAd__cctor_m4D010B4157713887DACE675D33EB96F2872C702A (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817* L_0 = (ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817*)il2cpp_codegen_object_new(ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var);
		ATInterstitialAd__ctor_m9874DE86B16F638ABC4E130FC010823146557BC7(L_0, NULL);
		((ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAd_t68C4D29B8572B16C2F1EFF99D6FC2BE0AA339817_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd__ctor_m72B186CF744A756B6942B0AC716B99B737E2F5F9 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATInterstitialAutoAd_GetATInterstitialAdClient_m4651472CE4648AB839281D7CCD53601284F8F769(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* ATInterstitialAutoAd_get_Instance_m298E3856D4B766EFA28593F5BEA1932A02F04066 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var);
		ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* L_0 = ((ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATInterstitialAutoAd_GetATInterstitialAdClient_m4651472CE4648AB839281D7CCD53601284F8F769 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildInterstitialAdClient_m6014DFF80BD26B751FAF92AE1B759DB7A5B7908D(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_addAutoLoadAdPlacementID_m94716EE069CB52600EBE304D144117685B5427DB (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_placementIDList, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_placementIDList;
		NullCheck(L_0);
		InterfaceActionInvoker1< StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* >::Invoke(8, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_removeAutoLoadAdPlacementID_m2386247EEF75E161C3D491765DB291835ED41F87 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_placementIDList, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0DA44B4B2555A4BCF3589D4EC74EB1AB1ACD9912);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral71C17B3684796D88DD17328DF65F347A856EAF31);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_placementIDList;
		if (!L_0)
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_placementIDList;
		NullCheck(L_1);
		if (!(((RuntimeArray*)L_1)->max_length))
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = ___0_placementIDList;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336((RuntimeObject*)L_2, NULL);
		V_0 = L_3;
		RuntimeObject* L_4 = __this->___client;
		String_t* L_5 = V_0;
		NullCheck(L_4);
		InterfaceActionInvoker1< String_t* >::Invoke(9, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_4, L_5);
		String_t* L_6 = V_0;
		String_t* L_7;
		L_7 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteral71C17B3684796D88DD17328DF65F347A856EAF31, L_6, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_7, NULL);
		return;
	}

IL_002b:
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral0DA44B4B2555A4BCF3589D4EC74EB1AB1ACD9912, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATInterstitialAutoAd_checkAutoAdStatus_m8DB83342E199CDBFAB1BED5132603CC42B298D4F (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(7, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATInterstitialAutoAd_autoLoadInterstitialAdReadyForPlacementID_m3C65A8C68976073D5D274F9B13E8575061FB11E0 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(10, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATInterstitialAutoAd_getAutoValidAdCaches_m3B3B9BAB5B7D51E398F199A112A78C2DC4B08E44 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(11, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_setAutoLocalExtra_m52C179BD2B4820ED13702DFF1DDBF2F537691BE4 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(12, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_entryAutoAdScenarioWithPlacementID_m98EB46FC950E1C74C616F32426F7B1D2CE888C10 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(13, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_showAutoAd_m4E74953270B8FFCF6BBA4268E6212567F499A4D5 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*)il2cpp_codegen_object_new(Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052(L_2, Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(14, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd_showAutoAd_mA078FA8FF6410BED30D716EE296E609045F84C93 (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(14, IATInterstitialAdClient_t8DE3DFDD0468982640EAE2198BEAE61407AE340C_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATInterstitialAutoAd__cctor_m0B8FAD8ED1C88245AC0D5AAA5F9891EBCB7BDDB1 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB* L_0 = (ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB*)il2cpp_codegen_object_new(ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var);
		ATInterstitialAutoAd__ctor_m72B186CF744A756B6942B0AC716B99B737E2F5F9(L_0, NULL);
		((ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_StaticFields*)il2cpp_codegen_static_fields_for(ATInterstitialAutoAd_t73C090E631B76B76539F75A908A8875FEF823DCB_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAdLoadingExtra__ctor_m9BAB14D6671C2FB03714755874FF7A2D31E34B80 (ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAdLoadingExtra__cctor_mF342A64077A7795B67A47F9147D15F3E404BAA9D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1388D53684B0996B3FF27203D1547660E4D82509);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC2174A5652A092BA4EA81CC88E05A4CF11987070);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE0560976B58269705E291202AB17A7D7F1543FA4);
		s_Il2CppMethodInitialized = true;
	}
	{
		((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSizeStruct = _stringLiteralC2174A5652A092BA4EA81CC88E05A4CF11987070;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSizeStruct), (void*)_stringLiteralC2174A5652A092BA4EA81CC88E05A4CF11987070);
		((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSize = _stringLiteralE0560976B58269705E291202AB17A7D7F1543FA4;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSize), (void*)_stringLiteralE0560976B58269705E291202AB17A7D7F1543FA4);
		((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdSizeUsesPixelFlagKey = _stringLiteral1388D53684B0996B3FF27203D1547660E4D82509;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdSizeUsesPixelFlagKey), (void*)_stringLiteral1388D53684B0996B3FF27203D1547660E4D82509);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd__ctor_m87494718B200DC48F14CEA528D1E59F8C50D2487 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATNativeAd_GetATNativeAdClient_m6DECED9819AD205496269D71232AE4335B893190(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* ATNativeAd_get_Instance_m0738FD67A771C17BE682EBD0294538BAC02D267F (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var);
		ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* L_0 = ((ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_loadNativeAd_mCEF862778A0C83362BA702083A93E72A653C0C70 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral062DB096C728515E033CF8C48A1C1F0B9A79384B);
		s_Il2CppMethodInitialized = true;
	}
	ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* V_0 = NULL;
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_0 = ___1_pairs;
		if (!L_0)
		{
			goto IL_0062;
		}
	}
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_1 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var);
		String_t* L_2 = ((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSizeStruct;
		NullCheck(L_1);
		bool L_3;
		L_3 = Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC(L_1, L_2, Dictionary_2_ContainsKey_m1A594D39FA446EBD9EA6FFBA95D3AB82D16565CC_RuntimeMethod_var);
		if (!L_3)
		{
			goto IL_0062;
		}
	}
	{
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_4 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var);
		String_t* L_5 = ((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSizeStruct;
		NullCheck(L_4);
		RuntimeObject* L_6;
		L_6 = Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5(L_4, L_5, Dictionary_2_get_Item_m371FC5B3D39406E297F2626B159BA1A3E32917B5_RuntimeMethod_var);
		V_0 = ((ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D*)CastclassClass((RuntimeObject*)L_6, ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D_il2cpp_TypeInfo_var));
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_7 = ___1_pairs;
		String_t* L_8 = ((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdLoadingExtraNativeAdSize;
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_9 = V_0;
		NullCheck(L_9);
		int32_t* L_10 = (int32_t*)(&L_9->___width);
		String_t* L_11;
		L_11 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5(L_10, NULL);
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_12 = V_0;
		NullCheck(L_12);
		int32_t* L_13 = (int32_t*)(&L_12->___height);
		String_t* L_14;
		L_14 = Int32_ToString_m030E01C24E294D6762FB0B6F37CB541581F55CA5(L_13, NULL);
		String_t* L_15;
		L_15 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(L_11, _stringLiteral062DB096C728515E033CF8C48A1C1F0B9A79384B, L_14, NULL);
		NullCheck(L_7);
		Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443(L_7, L_8, L_15, Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_16 = ___1_pairs;
		String_t* L_17 = ((ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAdLoadingExtra_tD57B2018036CA3FCCC6FC6645E41B7B53C50E98D_il2cpp_TypeInfo_var))->___kATNativeAdSizeUsesPixelFlagKey;
		ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* L_18 = V_0;
		NullCheck(L_18);
		bool L_19 = L_18->___usesPixel;
		bool L_20 = L_19;
		RuntimeObject* L_21 = Box(Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_il2cpp_TypeInfo_var, &L_20);
		NullCheck(L_16);
		Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443(L_16, L_17, L_21, Dictionary_2_Add_m5875DF2ACE933D734119C088B2E7C9C63F49B443_RuntimeMethod_var);
	}

IL_0062:
	{
		RuntimeObject* L_22 = __this->___client;
		String_t* L_23 = ___0_placementId;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_24 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_25;
		L_25 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_24, NULL);
		NullCheck(L_22);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_22, L_23, L_25);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATNativeAd_hasAdReady_m1E2FFDD336680A14D791D2C86B0C3AC0CEED5F70 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(1, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATNativeAd_checkAdStatus_mB6BC1C6A19772C890F2AEE821531EA0259332498 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(2, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATNativeAd_getValidAdCaches_m8724611208CB23492E6FF0A0FA09BFE85C1B3036 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(9, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_entryScenarioWithPlacementID_m9EAE22CCAF85FB4B7836EBB2DDCD918EDA85B79E (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(10, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_renderAdToScene_mC378315BC3B2ECEE59E2B0852AA24353CFC1013C (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* ___1_anyThinkNativeAdView, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* L_2 = ___1_anyThinkNativeAdView;
		NullCheck(L_0);
		InterfaceActionInvoker3< String_t*, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C*, String_t* >::Invoke(4, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2, _stringLiteralDA39A3EE5E6B4B0D3255BFEF95601890AFD80709);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_renderAdToScene_mCA04C4E5CD0E67DDBBF8CB0886BB48D6637A9991 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* ___1_anyThinkNativeAdView, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___2_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* L_2 = ___1_anyThinkNativeAdView;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_3 = ___2_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_4;
		L_4 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_3, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker3< String_t*, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C*, String_t* >::Invoke(4, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_4);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_cleanAdView_mB463D1C45F8974DF8C1556C15A4FD1216E8F34C2 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* ___1_anyThinkNativeAdView, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* L_2 = ___1_anyThinkNativeAdView;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* >::Invoke(5, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_onApplicationForces_m520152FDB00CDE41DDEDF6E4D00A07D0EADC3A84 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* ___1_anyThinkNativeAdView, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* L_2 = ___1_anyThinkNativeAdView;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* >::Invoke(6, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_onApplicationPasue_m97B801AFFFB6073516DD6C1D76A8294AD465C200 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* ___1_anyThinkNativeAdView, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* L_2 = ___1_anyThinkNativeAdView;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* >::Invoke(7, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd_cleanCache_m4CA0E40F94A3EFB5E57B67188E4C4D801FBF5133 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(8, IATNativeAdClient_t55535B17E142EB4F34DF66497A466BB037D2C59C_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATNativeAd_GetATNativeAdClient_m6DECED9819AD205496269D71232AE4335B893190 (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildNativeAdClient_m77A89B3892F66666F279433A4BFD5841B174AA8B(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAd__cctor_m404482E8144304469CC5656AA2239B64723A928A (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB* L_0 = (ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB*)il2cpp_codegen_object_new(ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var);
		ATNativeAd__ctor_m87494718B200DC48F14CEA528D1E59F8C50D2487(L_0, NULL);
		((ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeAd_t2015F7596076CA06AF4B5854E81CEA0BD7E1B2FB_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeAdView__ctor_m98B3B96E70601E7034D24849A71E5219AD8C94D1 (ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* __this, ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* ___0_config, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral33018FA8926405B4E44C0D1902B3435E469A55E2);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral3A0638EF431254803510AEEF4E30E0DCB0C2E12D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral46EBAC5E8BDA7E4F7044E37E0C769312169C651B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral483DFA9A614472DBFD4B58265DDE1C943D92F756);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4C9820D0000A8721F54710F1ABFB2EDBFC71FDE8);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6697CDCB0762971428BEAB2CC086B115C9E38187);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC7B4D926EF9532A71B25AEC040A33D52C926425F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralEE88DB00CE4B2E2DC6AB5DCD8BBEB39289B25168);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralEF042A4C30146DF9FD9D245912DCA96150741EF5);
		s_Il2CppMethodInitialized = true;
	}
	{
		__this->___parentKey = _stringLiteral483DFA9A614472DBFD4B58265DDE1C943D92F756;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___parentKey), (void*)_stringLiteral483DFA9A614472DBFD4B58265DDE1C943D92F756);
		__this->___appIconKey = _stringLiteralEF042A4C30146DF9FD9D245912DCA96150741EF5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___appIconKey), (void*)_stringLiteralEF042A4C30146DF9FD9D245912DCA96150741EF5);
		__this->___mainImageKey = _stringLiteralEE88DB00CE4B2E2DC6AB5DCD8BBEB39289B25168;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___mainImageKey), (void*)_stringLiteralEE88DB00CE4B2E2DC6AB5DCD8BBEB39289B25168);
		__this->___titleKey = _stringLiteralC7B4D926EF9532A71B25AEC040A33D52C926425F;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___titleKey), (void*)_stringLiteralC7B4D926EF9532A71B25AEC040A33D52C926425F);
		__this->___descKey = _stringLiteral46EBAC5E8BDA7E4F7044E37E0C769312169C651B;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___descKey), (void*)_stringLiteral46EBAC5E8BDA7E4F7044E37E0C769312169C651B);
		__this->___adLogoKey = _stringLiteral3A0638EF431254803510AEEF4E30E0DCB0C2E12D;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___adLogoKey), (void*)_stringLiteral3A0638EF431254803510AEEF4E30E0DCB0C2E12D);
		__this->___ctaButtonKey = _stringLiteral4C9820D0000A8721F54710F1ABFB2EDBFC71FDE8;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___ctaButtonKey), (void*)_stringLiteral4C9820D0000A8721F54710F1ABFB2EDBFC71FDE8);
		__this->___dislikeButtonKey = _stringLiteral6697CDCB0762971428BEAB2CC086B115C9E38187;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___dislikeButtonKey), (void*)_stringLiteral6697CDCB0762971428BEAB2CC086B115C9E38187);
		__this->___elementsKey = _stringLiteral33018FA8926405B4E44C0D1902B3435E469A55E2;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___elementsKey), (void*)_stringLiteral33018FA8926405B4E44C0D1902B3435E469A55E2);
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_0 = ___0_config;
		__this->___config = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___config), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATNativeAdView_toJSON_m8AF47D7371236AD952DAB49C118A0D1BD524A8B4 (ATNativeAdView_tBBD4CA9EBDE5D330CC866EB249E872D5C287F18C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&StringBuilder_t_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677);
		s_Il2CppMethodInitialized = true;
	}
	StringBuilder_t* V_0 = NULL;
	String_t* V_1 = NULL;
	{
		StringBuilder_t* L_0 = (StringBuilder_t*)il2cpp_codegen_object_new(StringBuilder_t_il2cpp_TypeInfo_var);
		StringBuilder__ctor_m1D99713357DE05DAFA296633639DB55F8C30587D(L_0, NULL);
		V_0 = L_0;
		StringBuilder_t* L_1 = V_0;
		NullCheck(L_1);
		StringBuilder_t* L_2;
		L_2 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_1, _stringLiteral0C3C6829C3CCF8020C6AC45B87963ADC095CD44A, NULL);
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_3 = __this->___config;
		NullCheck(L_3);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_4 = L_3->___parentProperty;
		if (!L_4)
		{
			goto IL_006f;
		}
	}
	{
		StringBuilder_t* L_5 = V_0;
		NullCheck(L_5);
		StringBuilder_t* L_6;
		L_6 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_5, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_7 = __this->___parentKey;
		NullCheck(L_6);
		StringBuilder_t* L_8;
		L_8 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_6, L_7, NULL);
		NullCheck(L_8);
		StringBuilder_t* L_9;
		L_9 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_8, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_10 = V_0;
		NullCheck(L_10);
		StringBuilder_t* L_11;
		L_11 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_10, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_12 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_13 = __this->___config;
		NullCheck(L_13);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_14 = L_13->___parentProperty;
		String_t* L_15;
		L_15 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_14, NULL);
		NullCheck(L_12);
		StringBuilder_t* L_16;
		L_16 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_12, L_15, NULL);
		StringBuilder_t* L_17 = V_0;
		NullCheck(L_17);
		StringBuilder_t* L_18;
		L_18 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_17, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_006f:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_19 = __this->___config;
		NullCheck(L_19);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_20 = L_19->___appIconProperty;
		if (!L_20)
		{
			goto IL_00cc;
		}
	}
	{
		StringBuilder_t* L_21 = V_0;
		NullCheck(L_21);
		StringBuilder_t* L_22;
		L_22 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_21, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_23 = __this->___appIconKey;
		NullCheck(L_22);
		StringBuilder_t* L_24;
		L_24 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_22, L_23, NULL);
		NullCheck(L_24);
		StringBuilder_t* L_25;
		L_25 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_24, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_26 = V_0;
		NullCheck(L_26);
		StringBuilder_t* L_27;
		L_27 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_26, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_28 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_29 = __this->___config;
		NullCheck(L_29);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_30 = L_29->___appIconProperty;
		String_t* L_31;
		L_31 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_30, NULL);
		NullCheck(L_28);
		StringBuilder_t* L_32;
		L_32 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_28, L_31, NULL);
		StringBuilder_t* L_33 = V_0;
		NullCheck(L_33);
		StringBuilder_t* L_34;
		L_34 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_33, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_00cc:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_35 = __this->___config;
		NullCheck(L_35);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_36 = L_35->___mainImageProperty;
		if (!L_36)
		{
			goto IL_0129;
		}
	}
	{
		StringBuilder_t* L_37 = V_0;
		NullCheck(L_37);
		StringBuilder_t* L_38;
		L_38 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_37, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_39 = __this->___mainImageKey;
		NullCheck(L_38);
		StringBuilder_t* L_40;
		L_40 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_38, L_39, NULL);
		NullCheck(L_40);
		StringBuilder_t* L_41;
		L_41 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_40, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_42 = V_0;
		NullCheck(L_42);
		StringBuilder_t* L_43;
		L_43 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_42, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_44 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_45 = __this->___config;
		NullCheck(L_45);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_46 = L_45->___mainImageProperty;
		String_t* L_47;
		L_47 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_46, NULL);
		NullCheck(L_44);
		StringBuilder_t* L_48;
		L_48 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_44, L_47, NULL);
		StringBuilder_t* L_49 = V_0;
		NullCheck(L_49);
		StringBuilder_t* L_50;
		L_50 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_49, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_0129:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_51 = __this->___config;
		NullCheck(L_51);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_52 = L_51->___titleProperty;
		if (!L_52)
		{
			goto IL_0186;
		}
	}
	{
		StringBuilder_t* L_53 = V_0;
		NullCheck(L_53);
		StringBuilder_t* L_54;
		L_54 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_53, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_55 = __this->___titleKey;
		NullCheck(L_54);
		StringBuilder_t* L_56;
		L_56 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_54, L_55, NULL);
		NullCheck(L_56);
		StringBuilder_t* L_57;
		L_57 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_56, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_58 = V_0;
		NullCheck(L_58);
		StringBuilder_t* L_59;
		L_59 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_58, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_60 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_61 = __this->___config;
		NullCheck(L_61);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_62 = L_61->___titleProperty;
		String_t* L_63;
		L_63 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_62, NULL);
		NullCheck(L_60);
		StringBuilder_t* L_64;
		L_64 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_60, L_63, NULL);
		StringBuilder_t* L_65 = V_0;
		NullCheck(L_65);
		StringBuilder_t* L_66;
		L_66 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_65, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_0186:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_67 = __this->___config;
		NullCheck(L_67);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_68 = L_67->___descProperty;
		if (!L_68)
		{
			goto IL_01e3;
		}
	}
	{
		StringBuilder_t* L_69 = V_0;
		NullCheck(L_69);
		StringBuilder_t* L_70;
		L_70 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_69, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_71 = __this->___descKey;
		NullCheck(L_70);
		StringBuilder_t* L_72;
		L_72 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_70, L_71, NULL);
		NullCheck(L_72);
		StringBuilder_t* L_73;
		L_73 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_72, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_74 = V_0;
		NullCheck(L_74);
		StringBuilder_t* L_75;
		L_75 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_74, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_76 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_77 = __this->___config;
		NullCheck(L_77);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_78 = L_77->___descProperty;
		String_t* L_79;
		L_79 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_78, NULL);
		NullCheck(L_76);
		StringBuilder_t* L_80;
		L_80 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_76, L_79, NULL);
		StringBuilder_t* L_81 = V_0;
		NullCheck(L_81);
		StringBuilder_t* L_82;
		L_82 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_81, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_01e3:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_83 = __this->___config;
		NullCheck(L_83);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_84 = L_83->___adLogoProperty;
		if (!L_84)
		{
			goto IL_0240;
		}
	}
	{
		StringBuilder_t* L_85 = V_0;
		NullCheck(L_85);
		StringBuilder_t* L_86;
		L_86 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_85, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_87 = __this->___adLogoKey;
		NullCheck(L_86);
		StringBuilder_t* L_88;
		L_88 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_86, L_87, NULL);
		NullCheck(L_88);
		StringBuilder_t* L_89;
		L_89 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_88, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_90 = V_0;
		NullCheck(L_90);
		StringBuilder_t* L_91;
		L_91 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_90, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_92 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_93 = __this->___config;
		NullCheck(L_93);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_94 = L_93->___adLogoProperty;
		String_t* L_95;
		L_95 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_94, NULL);
		NullCheck(L_92);
		StringBuilder_t* L_96;
		L_96 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_92, L_95, NULL);
		StringBuilder_t* L_97 = V_0;
		NullCheck(L_97);
		StringBuilder_t* L_98;
		L_98 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_97, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_0240:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_99 = __this->___config;
		NullCheck(L_99);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_100 = L_99->___ctaButtonProperty;
		if (!L_100)
		{
			goto IL_029d;
		}
	}
	{
		StringBuilder_t* L_101 = V_0;
		NullCheck(L_101);
		StringBuilder_t* L_102;
		L_102 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_101, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_103 = __this->___ctaButtonKey;
		NullCheck(L_102);
		StringBuilder_t* L_104;
		L_104 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_102, L_103, NULL);
		NullCheck(L_104);
		StringBuilder_t* L_105;
		L_105 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_104, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_106 = V_0;
		NullCheck(L_106);
		StringBuilder_t* L_107;
		L_107 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_106, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_108 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_109 = __this->___config;
		NullCheck(L_109);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_110 = L_109->___ctaButtonProperty;
		String_t* L_111;
		L_111 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_110, NULL);
		NullCheck(L_108);
		StringBuilder_t* L_112;
		L_112 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_108, L_111, NULL);
		StringBuilder_t* L_113 = V_0;
		NullCheck(L_113);
		StringBuilder_t* L_114;
		L_114 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_113, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_029d:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_115 = __this->___config;
		NullCheck(L_115);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_116 = L_115->___dislikeButtonProperty;
		if (!L_116)
		{
			goto IL_02fa;
		}
	}
	{
		StringBuilder_t* L_117 = V_0;
		NullCheck(L_117);
		StringBuilder_t* L_118;
		L_118 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_117, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_119 = __this->___dislikeButtonKey;
		NullCheck(L_118);
		StringBuilder_t* L_120;
		L_120 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_118, L_119, NULL);
		NullCheck(L_120);
		StringBuilder_t* L_121;
		L_121 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_120, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_122 = V_0;
		NullCheck(L_122);
		StringBuilder_t* L_123;
		L_123 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_122, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_124 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_125 = __this->___config;
		NullCheck(L_125);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_126 = L_125->___dislikeButtonProperty;
		String_t* L_127;
		L_127 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_126, NULL);
		NullCheck(L_124);
		StringBuilder_t* L_128;
		L_128 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_124, L_127, NULL);
		StringBuilder_t* L_129 = V_0;
		NullCheck(L_129);
		StringBuilder_t* L_130;
		L_130 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_129, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
	}

IL_02fa:
	{
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_131 = __this->___config;
		NullCheck(L_131);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_132 = L_131->___elementsProperty;
		if (!L_132)
		{
			goto IL_034b;
		}
	}
	{
		StringBuilder_t* L_133 = V_0;
		NullCheck(L_133);
		StringBuilder_t* L_134;
		L_134 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_133, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		String_t* L_135 = __this->___elementsKey;
		NullCheck(L_134);
		StringBuilder_t* L_136;
		L_136 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_134, L_135, NULL);
		NullCheck(L_136);
		StringBuilder_t* L_137;
		L_137 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_136, _stringLiteralC62C64F00567C5368CAE37F4E64E1E82FF785677, NULL);
		StringBuilder_t* L_138 = V_0;
		NullCheck(L_138);
		StringBuilder_t* L_139;
		L_139 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_138, _stringLiteral876C4B39B6E4D0187090400768899C71D99DE90D, NULL);
		StringBuilder_t* L_140 = V_0;
		ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* L_141 = __this->___config;
		NullCheck(L_141);
		ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* L_142 = L_141->___elementsProperty;
		String_t* L_143;
		L_143 = JsonUtility_ToJson_m28CC6843B9D3723D88AD13EA3829B71FDE7826BA(L_142, NULL);
		NullCheck(L_140);
		StringBuilder_t* L_144;
		L_144 = StringBuilder_Append_m08904D74E0C78E5F36DCD9C9303BDD07886D9F7D(L_140, L_143, NULL);
	}

IL_034b:
	{
		StringBuilder_t* L_145 = V_0;
		NullCheck(L_145);
		String_t* L_146;
		L_146 = VirtualFuncInvoker0< String_t* >::Invoke(3, L_145);
		V_1 = L_146;
		String_t* L_147 = V_1;
		NullCheck(L_147);
		bool L_148;
		L_148 = String_EndsWith_mCD3754F5401E19CE7821CD398986E4EAA6AD87DC(L_147, _stringLiteralC18C9BB6DF0D5C60CE5A5D2D3D6111BEB6F8CCEB, NULL);
		if (!L_148)
		{
			goto IL_036f;
		}
	}
	{
		String_t* L_149 = V_1;
		String_t* L_150 = V_1;
		NullCheck(L_150);
		int32_t L_151;
		L_151 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_150, NULL);
		NullCheck(L_149);
		String_t* L_152;
		L_152 = String_Substring_mB1D94F47935D22E130FF2C01DBB6A4135FBB76CE(L_149, 0, ((int32_t)il2cpp_codegen_subtract(L_151, 1)), NULL);
		V_1 = L_152;
	}

IL_036f:
	{
		String_t* L_153 = V_1;
		String_t* L_154;
		L_154 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(L_153, _stringLiteral4D8D9C94AC5DA5FCED2EC8A64E10E714A2515C30, NULL);
		V_1 = L_154;
		String_t* L_155 = V_1;
		return L_155;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAdShowingExtra__ctor_mD5BE5E8E5FADE92478A619C631B3C4E72D3953EE (ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAdShowingExtra__cctor_mC2FD924038D90CF2423EB7946CCA98A755600F19 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0BABBCE95BCD478A1457643796BE96B9ACA4E6C2);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1084E0508EC132638288C6F0A8F166242775D100);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral10CFCF3EBD4D77E7A54DFD0926B0796496169AB9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2E52B4BC35C1F9068E8AD23DC9937D65194A5135);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6464580B4BA3FBA5EE5A3A1A31C35F8B2BB42CB9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral83A97723F7E5BDE036330459FB667402C7C32740);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral988090910866A3AC43E431323DD6916C60B1A59A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA76A1FBB5BDCCBC5DBCEDB47C87027870724AC3E);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB714933B91F72FB57380135D2B50660975351E49);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBC0048E68AAA6E10064F62D278CB090D1AAE69DF);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDE6D13D8B5CAB7B6CF611C5B25BC71DE7AA04FD5);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralEDCC39ACE1BE3A6CCC4D73DEDA17B26E795EF1D3);
		s_Il2CppMethodInitialized = true;
	}
	{
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraBackgroundColor = _stringLiteral0BABBCE95BCD478A1457643796BE96B9ACA4E6C2;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraBackgroundColor), (void*)_stringLiteral0BABBCE95BCD478A1457643796BE96B9ACA4E6C2);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAutorefreshInterval = _stringLiteralA76A1FBB5BDCCBC5DBCEDB47C87027870724AC3E;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAutorefreshInterval), (void*)_stringLiteralA76A1FBB5BDCCBC5DBCEDB47C87027870724AC3E);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraHideCloseButtonFlag = _stringLiteralEDCC39ACE1BE3A6CCC4D73DEDA17B26E795EF1D3;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraHideCloseButtonFlag), (void*)_stringLiteralEDCC39ACE1BE3A6CCC4D73DEDA17B26E795EF1D3);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTAButtonBackgroundColor = _stringLiteralB714933B91F72FB57380135D2B50660975351E49;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTAButtonBackgroundColor), (void*)_stringLiteralB714933B91F72FB57380135D2B50660975351E49);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTATextColor = _stringLiteral1084E0508EC132638288C6F0A8F166242775D100;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTATextColor), (void*)_stringLiteral1084E0508EC132638288C6F0A8F166242775D100);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTATextFont = _stringLiteral10CFCF3EBD4D77E7A54DFD0926B0796496169AB9;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraCTATextFont), (void*)_stringLiteral10CFCF3EBD4D77E7A54DFD0926B0796496169AB9);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTitleColor = _stringLiteralDE6D13D8B5CAB7B6CF611C5B25BC71DE7AA04FD5;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTitleColor), (void*)_stringLiteralDE6D13D8B5CAB7B6CF611C5B25BC71DE7AA04FD5);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTitleFont = _stringLiteral6464580B4BA3FBA5EE5A3A1A31C35F8B2BB42CB9;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTitleFont), (void*)_stringLiteral6464580B4BA3FBA5EE5A3A1A31C35F8B2BB42CB9);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTextColor = _stringLiteral83A97723F7E5BDE036330459FB667402C7C32740;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTextColor), (void*)_stringLiteral83A97723F7E5BDE036330459FB667402C7C32740);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTextFont = _stringLiteral988090910866A3AC43E431323DD6916C60B1A59A;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraTextFont), (void*)_stringLiteral988090910866A3AC43E431323DD6916C60B1A59A);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAdvertiserTextFont = _stringLiteralBC0048E68AAA6E10064F62D278CB090D1AAE69DF;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAdvertiserTextFont), (void*)_stringLiteralBC0048E68AAA6E10064F62D278CB090D1AAE69DF);
		((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAdvertiserTextColor = _stringLiteral2E52B4BC35C1F9068E8AD23DC9937D65194A5135;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAdShowingExtra_t0FE66289975CC9B69EDA88DB3846C945A42185A1_il2cpp_TypeInfo_var))->___kATNativeBannerAdShowingExtraAdvertiserTextColor), (void*)_stringLiteral2E52B4BC35C1F9068E8AD23DC9937D65194A5135);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd__ctor_m2B334A6D47425C7B2F8171950299AA57C02CB598 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATNativeBannerAd_GetATNativeBannerAdClient_mC1C8967325B4670DCC85ACFD3E9E108439BA1155(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* ATNativeBannerAd_get_Instance_m3B03E351D7C09FC59880CEFBF3748AC738C3953A (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var);
		ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* L_0 = ((ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd_loadAd_m37A1CD9D30333347A917E3AFE0D204F4A12DC109 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralDA29C31BF1A1235E83B36C818C313368D6188CA1);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_placementId;
		String_t* L_1;
		L_1 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(_stringLiteralDA29C31BF1A1235E83B36C818C313368D6188CA1, L_0, _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_1, NULL);
		RuntimeObject* L_2 = __this->___client;
		String_t* L_3 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_4 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_5;
		L_5 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_4, NULL);
		NullCheck(L_2);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var, L_2, L_3, L_5);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATNativeBannerAd_adReady_m646F568B7A0FBE06C3608C46B50FEB1EEC9031CB (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral292BD63800E4D7AB03958C97F752AA04D34A681B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D);
		s_Il2CppMethodInitialized = true;
	}
	{
		String_t* L_0 = ___0_placementId;
		String_t* L_1;
		L_1 = String_Concat_m8855A6DE10F84DA7F4EC113CADDB59873A25573B(_stringLiteral292BD63800E4D7AB03958C97F752AA04D34A681B, L_0, _stringLiteralB3F14BF976EFD974E34846B742502C802FABAE9D, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_1, NULL);
		RuntimeObject* L_2 = __this->___client;
		String_t* L_3 = ___0_placementId;
		NullCheck(L_2);
		bool L_4;
		L_4 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(1, IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var, L_2, L_3);
		return L_4;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd_setListener_m6C8F196F6AAFBF80338BBA1CAFEC768905D1DF7A (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, RuntimeObject* ___0_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral64ECDAF6849D3AB5BFABD37685135C6123A23CC3);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral64ECDAF6849D3AB5BFABD37685135C6123A23CC3, NULL);
		RuntimeObject* L_0 = __this->___client;
		RuntimeObject* L_1 = ___0_listener;
		NullCheck(L_0);
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(2, IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd_showAd_m7F95777594524B1F1313EF12D9D902C449706B35 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, String_t* ___0_placementId, ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2* ___1_rect, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___2_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7AFF5DCE6B762488699DFA749CC45116752C6045);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral7AFF5DCE6B762488699DFA749CC45116752C6045, NULL);
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2* L_2 = ___1_rect;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_3 = ___2_pairs;
		NullCheck(L_0);
		InterfaceActionInvoker3< String_t*, ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2*, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* >::Invoke(3, IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd_removeAd_m022A800D606E892948698C5AF703FE7EC0DAEBF9 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral10D904031D0D73164858E9561BEBF8188F164AF6);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral10D904031D0D73164858E9561BEBF8188F164AF6, NULL);
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(4, IATNativeBannerAdClient_tDA9467756C97EA5831BDDBB0ECB6E91396CBD294_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATNativeBannerAd_GetATNativeBannerAdClient_mC1C8967325B4670DCC85ACFD3E9E108439BA1155 (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildNativeBannerAdClient_m2AE4C998D94CD271CCFD1F8443E9F8C9B79DAEBC(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeBannerAd__cctor_m5F145C0DF42E44EB6EFC97E46D17B742E17553A7 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC* L_0 = (ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC*)il2cpp_codegen_object_new(ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var);
		ATNativeBannerAd__ctor_m2B334A6D47425C7B2F8171950299AA57C02CB598(L_0, NULL);
		((ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_StaticFields*)il2cpp_codegen_static_fields_for(ATNativeBannerAd_tE58854FA0A73E26146A20E25FF3F3D937203AFEC_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeConfig__ctor_m9DB58A9BD8A73593CBBCECC4575C4DE2159D9BFC (ATNativeConfig_t1C2488BAA15F3BE2BF56F58A95F48B386B9E9D1A* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeItemProperty__ctor_m6D8F5268F0BBA34E0D15E3AD8406295D5E8EE407 (ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, String_t* ___4_backgroundColor, String_t* ___5_textColor, int32_t ___6_textSize, bool ___7_usesPixel, bool ___8_isCustomClick, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_x;
		__this->___x = L_0;
		int32_t L_1 = ___1_y;
		__this->___y = L_1;
		int32_t L_2 = ___2_width;
		__this->___width = L_2;
		int32_t L_3 = ___3_height;
		__this->___height = L_3;
		bool L_4 = ___7_usesPixel;
		__this->___usesPixel = L_4;
		String_t* L_5 = ___4_backgroundColor;
		__this->___backgroundColor = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___backgroundColor), (void*)L_5);
		String_t* L_6 = ___5_textColor;
		__this->___textColor = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___textColor), (void*)L_6);
		int32_t L_7 = ___6_textSize;
		__this->___textSize = L_7;
		bool L_8 = ___8_isCustomClick;
		__this->___isCustomClick = L_8;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeItemProperty__ctor_m0F2B619C249E2E042AF4043C27EE1E2473E55DAA (ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, String_t* ___4_backgroundColor, String_t* ___5_textColor, int32_t ___6_textSize, bool ___7_usesPixel, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_x;
		__this->___x = L_0;
		int32_t L_1 = ___1_y;
		__this->___y = L_1;
		int32_t L_2 = ___2_width;
		__this->___width = L_2;
		int32_t L_3 = ___3_height;
		__this->___height = L_3;
		bool L_4 = ___7_usesPixel;
		__this->___usesPixel = L_4;
		String_t* L_5 = ___4_backgroundColor;
		__this->___backgroundColor = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___backgroundColor), (void*)L_5);
		String_t* L_6 = ___5_textColor;
		__this->___textColor = L_6;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___textColor), (void*)L_6);
		int32_t L_7 = ___6_textSize;
		__this->___textSize = L_7;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATNativeItemProperty__ctor_m31EEF326EAE5DAC02309791CDF66AF3280C2AB02 (ATNativeItemProperty_t58B41E7E5AB08D343652315D7CF53AD2EBB2349A* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, String_t* ___4_backgroundColor, String_t* ___5_textColor, int32_t ___6_textSize, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_x;
		__this->___x = L_0;
		int32_t L_1 = ___1_y;
		__this->___y = L_1;
		int32_t L_2 = ___2_width;
		__this->___width = L_2;
		int32_t L_3 = ___3_height;
		__this->___height = L_3;
		String_t* L_4 = ___4_backgroundColor;
		__this->___backgroundColor = L_4;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___backgroundColor), (void*)L_4);
		String_t* L_5 = ___5_textColor;
		__this->___textColor = L_5;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___textColor), (void*)L_5);
		int32_t L_6 = ___6_textSize;
		__this->___textSize = L_6;
		__this->___usesPixel = (bool)1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRect__ctor_mEAD6FA64BCE76E86CECC579BF03B8E3F5024B3F5 (ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, bool ___4_usesPixel, const RuntimeMethod* method) 
{
	{
		__this->___usesPixel = (bool)1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_x;
		__this->___x = L_0;
		int32_t L_1 = ___1_y;
		__this->___y = L_1;
		int32_t L_2 = ___2_width;
		__this->___width = L_2;
		int32_t L_3 = ___3_height;
		__this->___height = L_3;
		bool L_4 = ___4_usesPixel;
		__this->___usesPixel = L_4;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRect__ctor_m0011BEF1691B6799DACB4326FC3E15B64D9E7C7F (ATRect_tBBC85FAC20A1E12B1EB9F3CE00870B793834C7C2* __this, int32_t ___0_x, int32_t ___1_y, int32_t ___2_width, int32_t ___3_height, const RuntimeMethod* method) 
{
	{
		__this->___usesPixel = (bool)1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_x;
		__this->___x = L_0;
		int32_t L_1 = ___1_y;
		__this->___y = L_1;
		int32_t L_2 = ___2_width;
		__this->___width = L_2;
		int32_t L_3 = ___3_height;
		__this->___height = L_3;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSize__ctor_mE16151C14472CC1A868424ABFA4AE6A35BB09639 (ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* __this, int32_t ___0_width, int32_t ___1_height, bool ___2_usesPixel, const RuntimeMethod* method) 
{
	{
		__this->___usesPixel = (bool)1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_width;
		__this->___width = L_0;
		int32_t L_1 = ___1_height;
		__this->___height = L_1;
		bool L_2 = ___2_usesPixel;
		__this->___usesPixel = L_2;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSize__ctor_m7C82519D054C5610E1C7686C0D44185492B5C1DA (ATSize_tB526AFFCD84BA3CC54C85D8125F2B279B6C3588D* __this, int32_t ___0_width, int32_t ___1_height, const RuntimeMethod* method) 
{
	{
		__this->___usesPixel = (bool)1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___0_width;
		__this->___width = L_0;
		int32_t L_1 = ___1_height;
		__this->___height = L_1;
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo__ctor_m9777C43E623BB3F67D3A771999635555138DED42 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATRewardedAutoVideo_GetATRewardedClient_mDF7F88190674E801D86A79F892FD238E10F07566(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* ATRewardedAutoVideo_get_Instance_m588AD6DE117B18AB9C173B1359F4E08A64FB494F (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var);
		ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* L_0 = ((ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_addAutoLoadAdPlacementID_mB337B3A965548CF7D34BDF902BE8EB67856ED7FA (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_placementIDList, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_placementIDList;
		NullCheck(L_0);
		InterfaceActionInvoker1< StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* >::Invoke(8, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_removeAutoLoadAdPlacementID_mEC63071353AB0C213F2B0F8530A1DEBAE28486C2 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_placementIDList, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral0DA44B4B2555A4BCF3589D4EC74EB1AB1ACD9912);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral71C17B3684796D88DD17328DF65F347A856EAF31);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_placementIDList;
		if (!L_0)
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_placementIDList;
		NullCheck(L_1);
		if (!(((RuntimeArray*)L_1)->max_length))
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = ___0_placementIDList;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336((RuntimeObject*)L_2, NULL);
		V_0 = L_3;
		RuntimeObject* L_4 = __this->___client;
		String_t* L_5 = V_0;
		NullCheck(L_4);
		InterfaceActionInvoker1< String_t* >::Invoke(9, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_4, L_5);
		String_t* L_6 = V_0;
		String_t* L_7;
		L_7 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteral71C17B3684796D88DD17328DF65F347A856EAF31, L_6, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_7, NULL);
		return;
	}

IL_002b:
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral0DA44B4B2555A4BCF3589D4EC74EB1AB1ACD9912, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATRewardedAutoVideo_autoLoadRewardedVideoReadyForPlacementID_m69533C9A3A3414BD3F4E80603F410E717BEECB90 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(10, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATRewardedAutoVideo_getAutoValidAdCaches_mC6A51560F1A330E53BFD45DA5AED21014861993D (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(11, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATRewardedAutoVideo_checkAutoAdStatus_m65CD0428BB72E64228197B96E28C353597EA8B78 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(7, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_setAutoLocalExtra_m60F670E2EECAEFA9E11B4BEF0F7EAAA23B3A83FD (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(12, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_entryAutoAdScenarioWithPlacementID_m7656633EF91217BBD555A308342A86290DB6641A (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(13, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_showAutoAd_m7EEE6C140D7495164B7D1047F48E4E7995EA067B (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*)il2cpp_codegen_object_new(Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052(L_2, Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(14, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo_showAutoAd_mB3D0782C6CA4CB38CA63C85551BA0547DDF959FD (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(14, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATRewardedAutoVideo_GetATRewardedClient_mDF7F88190674E801D86A79F892FD238E10F07566 (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildRewardedVideoAdClient_m6DE6B8A9057F9081333F5BC2E3A3A2DA18958BBB(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedAutoVideo__cctor_m2016FDB1026E87DF9D79CA53D5CE172A357CAE2B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36* L_0 = (ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36*)il2cpp_codegen_object_new(ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var);
		ATRewardedAutoVideo__ctor_m9777C43E623BB3F67D3A771999635555138DED42(L_0, NULL);
		((ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedAutoVideo_t186A232BB8A51374EC69B092A3AE1E678BC0DE36_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo__ctor_mC1740A24437B415D0FE589D663F3F0874F5CDADD (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATRewardedVideo_GetATRewardedClient_m6AD500ECAA75AA0D99E6A59E9B530614EC8FE1D2(__this, NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* ATRewardedVideo_get_Instance_m7B2AFA4121B0DC19574B46F728E650FBD75C4BB4 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var);
		ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* L_0 = ((ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo_loadVideoAd_m7E6F5226094F7DE52F53ABA2D4C0BD51B520C677 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATRewardedVideo_hasAdReady_m2D10A6B6D155B132D61E5901EC459A3E74C919A1 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(2, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo_entryScenarioWithPlacementID_m8612F7AD969FCEF06C33A5D60591F7443D913C35 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(6, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATRewardedVideo_checkAdStatus_m4BFCCE95869FC70ADC09E915399EAA853564A3D4 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(3, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATRewardedVideo_getValidAdCaches_m411B2D68C294CB1C1BED1BD217B703BE00EFD40A (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(5, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo_showAd_m8D3F1348AB73304ECAAEBE73E5A220235EDC28F3 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83*)il2cpp_codegen_object_new(Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83_il2cpp_TypeInfo_var);
		Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052(L_2, Dictionary_2__ctor_m768E076F1E804CE4959F4E71D3E6A9ADE2F55052_RuntimeMethod_var);
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(4, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo_showAd_m4414BADFBF8DFF98D0B0C8C2F8917C088037FEA0 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, String_t* ___0_placementId, Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(4, IATRewardedVideoAdClient_t35B9B560532A6BE76B3EBACE8DEC4FD62C4496A9_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATRewardedVideo_GetATRewardedClient_m6AD500ECAA75AA0D99E6A59E9B530614EC8FE1D2 (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildRewardedVideoAdClient_m6DE6B8A9057F9081333F5BC2E3A3A2DA18958BBB(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATRewardedVideo__cctor_m45D485A48D4B52B98EF72B750DDAC24C9C07E9AD (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97* L_0 = (ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97*)il2cpp_codegen_object_new(ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var);
		ATRewardedVideo__ctor_mC1740A24437B415D0FE589D663F3F0874F5CDADD(L_0, NULL);
		((ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_StaticFields*)il2cpp_codegen_static_fields_for(ATRewardedVideo_tFF1F706884EA5B4FFF4DA6829157F6150DABFB97_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_initSDK_mC6C1934C881DA785B0FE2A85F66F92AFDF85700D (String_t* ___0_appId, String_t* ___1_appKey, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_appId;
		String_t* L_2 = ___1_appKey;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(0, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_initSDK_mBB46ED803FA714695DBE398B46284427921750C9 (String_t* ___0_appId, String_t* ___1_appKey, RuntimeObject* ___2_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_appId;
		String_t* L_2 = ___1_appKey;
		RuntimeObject* L_3 = ___2_listener;
		NullCheck(L_0);
		InterfaceActionInvoker3< String_t*, String_t*, RuntimeObject* >::Invoke(1, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_showDebuggerUI_m90BA44683972E49DBD69378E06FB5EEA3B19093D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		NullCheck(L_0);
		InterfaceActionInvoker0::Invoke(2, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_showDebuggerUI_mCF550231D9C66764E093BD574D147D91E4440D57 (String_t* ___0_debugKey, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_debugKey;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(3, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setGDPRLevel_mD31E83C9913CAD7026B00CC98541E9CE0F3692C2 (int32_t ___0_level, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		int32_t L_1 = ___0_level;
		NullCheck(L_0);
		InterfaceActionInvoker1< int32_t >::Invoke(5, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_getUserLocation_m126BC81D65B6DF960CDCFEE7299C4A335AEFA1C1 (RuntimeObject* ___0_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		RuntimeObject* L_1 = ___0_listener;
		NullCheck(L_0);
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(4, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t ATSDKAPI_getGDPRLevel_m46535B3062300B6F1EB432444F77706EF5868B4D (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		NullCheck(L_0);
		int32_t L_1;
		L_1 = InterfaceFuncInvoker0< int32_t >::Invoke(14, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATSDKAPI_isEUTraffic_m7F75526B3F23FCAD0860748435F6AE2CD3764C99 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		NullCheck(L_0);
		bool L_1;
		L_1 = InterfaceFuncInvoker0< bool >::Invoke(15, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0);
		return L_1;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setChannel_m627CD3E8C90B54EECA6C71D1FDD908C4EAE9A414 (String_t* ___0_channel, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_channel;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(9, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setSubChannel_m49C64A1D68C12E28D2CA74BB6C166C70BAEDC93E (String_t* ___0_subChannel, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_1 = ___0_subChannel;
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(10, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_initCustomMap_mCA0256359643C990B50DC1BF8A1B9C1657852B68 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___0_customMap, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_1 = ___0_customMap;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_2;
		L_2 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_1, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker1< String_t* >::Invoke(11, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setCustomDataForPlacementID_m44CCA5F8AB1E4AF09511FBEE1DA2401ADD1757C5 (Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* ___0_customData, String_t* ___1_placementID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		Dictionary_2_t46B2DB028096FA2B828359E52F37F3105A83AD83* L_1 = ___0_customData;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_2;
		L_2 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_1, NULL);
		String_t* L_3 = ___1_placementID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(12, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_2, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_showGDPRAuth_mC6D97AD32A28E6ECEA171F8A8D1974FE7859DC9E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		NullCheck(L_0);
		InterfaceActionInvoker0::Invoke(6, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_showGDPRConsentDialog_m4D8D7BD2F2F2E0C517D74947FF41793977B1AD38 (RuntimeObject* ___0_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		RuntimeObject* L_1 = ___0_listener;
		NullCheck(L_0);
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(7, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setLogDebug_m4B2FEEA8804FEA048E0E298CEAAA29987F987FE9 (bool ___0_isDebug, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		bool L_1 = ___0_isDebug;
		NullCheck(L_0);
		InterfaceActionInvoker1< bool >::Invoke(13, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		bool L_2 = ___0_isDebug;
		ATLogger_set_IsDebug_m56AA630766065D05050ECC2F81BB817DE9E7A4B5_inline(L_2, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_addNetworkGDPRInfo_m9FBD67F927C7DE6A559195342AA2E05EA0F5FD41 (int32_t ___0_networkType, Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* ___1_dictionary, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		int32_t L_1 = ___0_networkType;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_2 = ___1_dictionary;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< int32_t, String_t* >::Invoke(8, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_deniedUploadDeviceInfo_m55B4EA3CA58AEE81BBBE927BC63C062A760F8E23 (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_deniedInfo, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral03B000D2C4DAFF596116BD3AC596F41D96CFF5B9);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral6CC49087803A7B2C8D0F9B2626880FF8EC4FF94C);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_deniedInfo;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_deniedInfo;
		NullCheck(L_1);
		if (!(((RuntimeArray*)L_1)->max_length))
		{
			goto IL_002a;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = ___0_deniedInfo;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336((RuntimeObject*)L_2, NULL);
		V_0 = L_3;
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_4 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_5 = V_0;
		NullCheck(L_4);
		InterfaceActionInvoker1< String_t* >::Invoke(16, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_4, L_5);
		String_t* L_6 = V_0;
		String_t* L_7;
		L_7 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteral03B000D2C4DAFF596116BD3AC596F41D96CFF5B9, L_6, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_7, NULL);
		return;
	}

IL_002a:
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral6CC49087803A7B2C8D0F9B2626880FF8EC4FF94C, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* ATSDKAPI_GetATSDKAPIClient_mC07322C0D667CF517304DF23CEFE5DB4B9A56FD9 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral9042595A1005F3694F667150D68011E6E1B221D7);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral9042595A1005F3694F667150D68011E6E1B221D7, NULL);
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildSDKAPIClient_m5E785FB8DD24EE905E3350F0BBFBEC9BAA5F3863(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setExcludeBundleIdArray_m9449CB1F3A647B2B917E9751341CC6D67E86F5A7 (StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___0_bundleIds, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral90777CC080B8210DFA568244B6C673ACA06D9BFF);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralC5AEAC59DFAF8098FFEBA846B955A932F758E831);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___0_bundleIds;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___0_bundleIds;
		NullCheck(L_1);
		if (!(((RuntimeArray*)L_1)->max_length))
		{
			goto IL_002a;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = ___0_bundleIds;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336((RuntimeObject*)L_2, NULL);
		V_0 = L_3;
		String_t* L_4 = V_0;
		String_t* L_5;
		L_5 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteralC5AEAC59DFAF8098FFEBA846B955A932F758E831, L_4, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_5, NULL);
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_6 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_7 = V_0;
		NullCheck(L_6);
		InterfaceActionInvoker1< String_t* >::Invoke(17, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_6, L_7);
		return;
	}

IL_002a:
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral90777CC080B8210DFA568244B6C673ACA06D9BFF, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setExcludeAdSourceIdArrayForPlacementID_mEFA44CB389A03788DF08D04E3145BB58DB5AE972 (String_t* ___0_placementID, StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* ___1_adSourceIds, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral171032605001E1912A8A0600431BF07A1726537F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1D1EFCF52A4E0FA49E30A3DE65058928ACB5EF13);
		s_Il2CppMethodInitialized = true;
	}
	String_t* V_0 = NULL;
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_0 = ___1_adSourceIds;
		if (!L_0)
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_1 = ___1_adSourceIds;
		NullCheck(L_1);
		if (!(((RuntimeArray*)L_1)->max_length))
		{
			goto IL_002b;
		}
	}
	{
		StringU5BU5D_t7674CD946EC0CE7B3AE0BE70E6EE85F2ECD9F248* L_2 = ___1_adSourceIds;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336((RuntimeObject*)L_2, NULL);
		V_0 = L_3;
		String_t* L_4 = V_0;
		String_t* L_5;
		L_5 = String_Concat_m9E3155FB84015C823606188F53B47CB44C444991(_stringLiteral1D1EFCF52A4E0FA49E30A3DE65058928ACB5EF13, L_4, NULL);
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(L_5, NULL);
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_6 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		String_t* L_7 = ___0_placementID;
		String_t* L_8 = V_0;
		NullCheck(L_6);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(18, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_6, L_7, L_8);
		return;
	}

IL_002b:
	{
		il2cpp_codegen_runtime_class_init_inline(Debug_t8394C7EEAECA3689C2C9B9DE9C7166D73596276F_il2cpp_TypeInfo_var);
		Debug_Log_m87A9A3C761FF5C43ED8A53B16190A53D08F818BB(_stringLiteral171032605001E1912A8A0600431BF07A1726537F, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setSDKArea_mDC4BFB3B88E905AF591A393167C3E4AC5D056166 (int32_t ___0_area, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		int32_t L_1 = ___0_area;
		NullCheck(L_0);
		InterfaceActionInvoker1< int32_t >::Invoke(19, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_getArea_m09DFF923A58F015CD534C61B269320C3EFBB5E89 (RuntimeObject* ___0_listener, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		RuntimeObject* L_1 = ___0_listener;
		NullCheck(L_0);
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(20, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setWXStatus_m6762BDD83EAAEF3D762902BC1E804BD0B6ABC494 (bool ___0_install, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		bool L_1 = ___0_install;
		NullCheck(L_0);
		InterfaceActionInvoker1< bool >::Invoke(21, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI_setLocation_mBA2FBDCA15C3DFAB6927BAF93DBB083EA8C768F0 (double ___0_longitude, double ___1_latitude, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		RuntimeObject* L_0 = ((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client;
		double L_1 = ___0_longitude;
		double L_2 = ___1_latitude;
		NullCheck(L_0);
		InterfaceActionInvoker2< double, double >::Invoke(22, IATSDKAPIClient_tC0FECACCA46F6FA8F6FEF3A5A112BBA10245A01B_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI__ctor_m57CBB46BD9926BDDBB612BD8B34D8EEE069D63A5 (ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSDKAPI__cctor_m1120A5262C6CE40D946F2C8043916990579AB105 (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral16AE29D4982527C4C7A6AF3EB4314E66EAD38294);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral170AD99AD2A9FB6605C713D5E03E562C7D968B69);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1745ECCF09CB581FB30F96360D0D0E8B3E0AD134);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral19A4DD21BBFD4F7063C65CBD5B8DEB0688B58B10);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2512497A38103E878C0A6145651B419DEE131154);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral25705477E232DDE539315FA572A0CE775D407106);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral2FCC894C8E31955BBEE1DA8D542825C6EFA4CC19);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral33F6758AC1777DAA0016096F040CBC13B8AB090F);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral486C5E022B623208CEC796B9BCD2F72E31E8A072);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral778F4B6769BD76BEA1B6F935EF09DAE5B686E017);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral7DD4F702FB1B016670C03544EB428F980A55531C);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral8769D5429AA71436D34F062199813C43C7D11E01);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA56563187CE402C2D214D1D438FAEFE383069121);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA582AFCA1811C5E0A07C5B63E7A046DFA7087D1A);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralA5B0B11BB35DDF1357AB0D80F47D1B74FAA4E9A8);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralBFB810260B3D8BC7FC286E1DFC7D03ED191A782B);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCB95AC6F5DAF4F3EB9438A7F55847FF126519704);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralCC1F7052057A1EC518E41F548AA4C5A4BA47C59D);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralE652D195EED39893D696733B289E29130B7D0A52);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF18D9351ADB98D1E281ABDAE06CD78D7EA630828);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralF455F86FAE600437E02E61A410A984183EB8EC54);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFA590547E6EFCCA8DA15CB0A84030B57AFDE8FA4);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteralFCEC1331B0ED56283A557BB3EE79406A80D474CC);
		s_Il2CppMethodInitialized = true;
	}
	{
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___kATUserLocationUnknown = 0;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___kATUserLocationInEU = 1;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___kATUserLocationOutOfEU = 2;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___PERSONALIZED = 0;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___NONPERSONALIZED = 1;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___UNKNOWN = 2;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___AREA_GLOBAL = 0;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___AREA_CHINESE_MAINLAND = 1;
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OS_VERSION_NAME = _stringLiteralA5B0B11BB35DDF1357AB0D80F47D1B74FAA4E9A8;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OS_VERSION_NAME), (void*)_stringLiteralA5B0B11BB35DDF1357AB0D80F47D1B74FAA4E9A8);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OS_VERSION_CODE = _stringLiteralBFB810260B3D8BC7FC286E1DFC7D03ED191A782B;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OS_VERSION_CODE), (void*)_stringLiteralBFB810260B3D8BC7FC286E1DFC7D03ED191A782B);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_PACKAGE_NAME = _stringLiteralA56563187CE402C2D214D1D438FAEFE383069121;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_PACKAGE_NAME), (void*)_stringLiteralA56563187CE402C2D214D1D438FAEFE383069121);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_VERSION_NAME = _stringLiteral16AE29D4982527C4C7A6AF3EB4314E66EAD38294;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_VERSION_NAME), (void*)_stringLiteral16AE29D4982527C4C7A6AF3EB4314E66EAD38294);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_VERSION_CODE = _stringLiteralA582AFCA1811C5E0A07C5B63E7A046DFA7087D1A;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___APP_VERSION_CODE), (void*)_stringLiteralA582AFCA1811C5E0A07C5B63E7A046DFA7087D1A);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___BRAND = _stringLiteral2FCC894C8E31955BBEE1DA8D542825C6EFA4CC19;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___BRAND), (void*)_stringLiteral2FCC894C8E31955BBEE1DA8D542825C6EFA4CC19);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MODEL = _stringLiteralCB95AC6F5DAF4F3EB9438A7F55847FF126519704;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MODEL), (void*)_stringLiteralCB95AC6F5DAF4F3EB9438A7F55847FF126519704);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___DEVICE_SCREEN_SIZE = _stringLiteral33F6758AC1777DAA0016096F040CBC13B8AB090F;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___DEVICE_SCREEN_SIZE), (void*)_stringLiteral33F6758AC1777DAA0016096F040CBC13B8AB090F);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MNC = _stringLiteral1745ECCF09CB581FB30F96360D0D0E8B3E0AD134;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MNC), (void*)_stringLiteral1745ECCF09CB581FB30F96360D0D0E8B3E0AD134);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MCC = _stringLiteralFCEC1331B0ED56283A557BB3EE79406A80D474CC;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MCC), (void*)_stringLiteralFCEC1331B0ED56283A557BB3EE79406A80D474CC);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___LANGUAGE = _stringLiteralCC1F7052057A1EC518E41F548AA4C5A4BA47C59D;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___LANGUAGE), (void*)_stringLiteralCC1F7052057A1EC518E41F548AA4C5A4BA47C59D);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___TIMEZONE = _stringLiteralF18D9351ADB98D1E281ABDAE06CD78D7EA630828;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___TIMEZONE), (void*)_stringLiteralF18D9351ADB98D1E281ABDAE06CD78D7EA630828);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___USER_AGENT = _stringLiteral19A4DD21BBFD4F7063C65CBD5B8DEB0688B58B10;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___USER_AGENT), (void*)_stringLiteral19A4DD21BBFD4F7063C65CBD5B8DEB0688B58B10);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___ORIENTATION = _stringLiteral8769D5429AA71436D34F062199813C43C7D11E01;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___ORIENTATION), (void*)_stringLiteral8769D5429AA71436D34F062199813C43C7D11E01);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___NETWORK_TYPE = _stringLiteral25705477E232DDE539315FA572A0CE775D407106;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___NETWORK_TYPE), (void*)_stringLiteral25705477E232DDE539315FA572A0CE775D407106);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___INSTALLER = _stringLiteralFA590547E6EFCCA8DA15CB0A84030B57AFDE8FA4;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___INSTALLER), (void*)_stringLiteralFA590547E6EFCCA8DA15CB0A84030B57AFDE8FA4);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___ANDROID_ID = _stringLiteral7DD4F702FB1B016670C03544EB428F980A55531C;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___ANDROID_ID), (void*)_stringLiteral7DD4F702FB1B016670C03544EB428F980A55531C);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___GAID = _stringLiteral2512497A38103E878C0A6145651B419DEE131154;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___GAID), (void*)_stringLiteral2512497A38103E878C0A6145651B419DEE131154);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MAC = _stringLiteral778F4B6769BD76BEA1B6F935EF09DAE5B686E017;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___MAC), (void*)_stringLiteral778F4B6769BD76BEA1B6F935EF09DAE5B686E017);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IMEI = _stringLiteralF455F86FAE600437E02E61A410A984183EB8EC54;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IMEI), (void*)_stringLiteralF455F86FAE600437E02E61A410A984183EB8EC54);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OAID = _stringLiteralE652D195EED39893D696733B289E29130B7D0A52;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___OAID), (void*)_stringLiteralE652D195EED39893D696733B289E29130B7D0A52);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IDFA = _stringLiteral486C5E022B623208CEC796B9BCD2F72E31E8A072;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IDFA), (void*)_stringLiteral486C5E022B623208CEC796B9BCD2F72E31E8A072);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IDFV = _stringLiteral170AD99AD2A9FB6605C713D5E03E562C7D968B69;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___IDFV), (void*)_stringLiteral170AD99AD2A9FB6605C713D5E03E562C7D968B69);
		RuntimeObject* L_0;
		L_0 = ATSDKAPI_GetATSDKAPIClient_mC07322C0D667CF517304DF23CEFE5DB4B9A56FD9(NULL);
		((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_StaticFields*)il2cpp_codegen_static_fields_for(ATSDKAPI_t4CE0C8E765865404AA542212BE9927D72159C7C6_il2cpp_TypeInfo_var))->___client), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAdLocalExtra__ctor_m0197DB00EC1BCD464D56F06C659C8492DB206B89 (ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAdLocalExtra__cctor_m2B1BE95D36DC8AC0D11556FEECE71E315FA9463E (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&_stringLiteral1E311C21F2D76CF060E680B7BEFF2383C44D3F9F);
		s_Il2CppMethodInitialized = true;
	}
	{
		((ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_StaticFields*)il2cpp_codegen_static_fields_for(ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_il2cpp_TypeInfo_var))->___kATSplashAdClickConfirmStatus = _stringLiteral1E311C21F2D76CF060E680B7BEFF2383C44D3F9F;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_StaticFields*)il2cpp_codegen_static_fields_for(ATSplashAdLocalExtra_t1EA564C3FC86C9B4EA1AD37F77130BB55CFE6E69_il2cpp_TypeInfo_var))->___kATSplashAdClickConfirmStatus), (void*)_stringLiteral1E311C21F2D76CF060E680B7BEFF2383C44D3F9F);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd__ctor_m4EE06DD2DB2C2A1F90AD7288978D2C4436DAAB97 (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		RuntimeObject* L_0;
		L_0 = ATAdsClientFactory_BuildSplashAdClient_m6EA782E7C65779D08A095CAC1A9B30DEBFA918AC(NULL);
		__this->___client = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___client), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* ATSplashAd_get_Instance_m02B049DA9FD06818052D4D6F73969D5945766F6F (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var);
		ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* L_0 = ((ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_StaticFields*)il2cpp_codegen_static_fields_for(ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var))->___instance;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd_loadSplashAd_m7A2C602ABAE617AB2C5D279571C4D7F5F28AB417 (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* ___1_pairs, int32_t ___2_fetchAdTimeout, String_t* ___3_defaultAdSourceConfig, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		int32_t L_2 = ___2_fetchAdTimeout;
		String_t* L_3 = ___3_defaultAdSourceConfig;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_4 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_5;
		L_5 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_4, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker4< String_t*, int32_t, String_t*, String_t* >::Invoke(0, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1, L_2, L_3, L_5);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd_showSplashAd_m700D2E5FB6CBBD6398B3DD422265B5BE99353E4A (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* ___1_pairs, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		Dictionary_2_tA348003A3C1CEFB3096E9D2A0BC7F1AC8EC4F710* L_2 = ___1_pairs;
		il2cpp_codegen_runtime_class_init_inline(JsonMapper_t6C02C11E5758BFDB34AD6A5F41ABBFC7FAB2E598_il2cpp_TypeInfo_var);
		String_t* L_3;
		L_3 = JsonMapper_ToJson_m640303EB0458D6FC503ACB6AFECB29F3EAC84336(L_2, NULL);
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(4, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1, L_3);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ATSplashAd_hasSplashAdReady_m9DF6A6EC0E99E6CC824E710CCE2A39292ED292DE (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		bool L_2;
		L_2 = InterfaceFuncInvoker1< bool, String_t* >::Invoke(2, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATSplashAd_checkAdStatus_m4D850EA023B6505E23AF5ED3A5CB1C5F9F5DBDDB (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(3, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR String_t* ATSplashAd_getValidAdCaches_m79315C221EFA743AA50D0A4FC6F70E91012E53BA (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		NullCheck(L_0);
		String_t* L_2;
		L_2 = InterfaceFuncInvoker1< String_t*, String_t* >::Invoke(5, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1);
		return L_2;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd_entryScenarioWithPlacementID_m59540B863F0E67E723D34BD9401E0AC4AE4BB6E5 (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* __this, String_t* ___0_placementId, String_t* ___1_scenarioID, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = __this->___client;
		String_t* L_1 = ___0_placementId;
		String_t* L_2 = ___1_scenarioID;
		NullCheck(L_0);
		InterfaceActionInvoker2< String_t*, String_t* >::Invoke(6, IATSplashAdClient_t2575D3C03B0CEC7A7E712222A3E2270A94E13F1A_il2cpp_TypeInfo_var, L_0, L_1, L_2);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ATSplashAd__cctor_m888D32FF35B69FC06D3E95E04A2F7B43F874613B (const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C* L_0 = (ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C*)il2cpp_codegen_object_new(ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var);
		ATSplashAd__ctor_m4EE06DD2DB2C2A1F90AD7288978D2C4436DAAB97(L_0, NULL);
		((ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_StaticFields*)il2cpp_codegen_static_fields_for(ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var))->___instance = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&((ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_StaticFields*)il2cpp_codegen_static_fields_for(ATSplashAd_tBF1801532C5F27174CAD8FA15763B7C70655710C_il2cpp_TypeInfo_var))->___instance), (void*)L_0);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t U3CPrivateImplementationDetailsU3E_ComputeStringHash_m6EA1F233618497AEFF8902A5EDFA24C74E2F2876 (String_t* ___0_s, const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		String_t* L_0 = ___0_s;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		V_0 = ((int32_t)-2128831035);
		V_1 = 0;
		goto IL_0021;
	}

IL_000d:
	{
		String_t* L_1 = ___0_s;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		Il2CppChar L_3;
		L_3 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_1, L_2, NULL);
		uint32_t L_4 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_multiply(((int32_t)((int32_t)L_3^(int32_t)L_4)), ((int32_t)16777619)));
		int32_t L_5 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
	}

IL_0021:
	{
		int32_t L_6 = V_1;
		String_t* L_7 = ___0_s;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_7, NULL);
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_000d;
		}
	}

IL_002a:
	{
		uint32_t L_9 = V_0;
		return L_9;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void ATLogger_set_IsDebug_m56AA630766065D05050ECC2F81BB817DE9E7A4B5_inline (bool ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		bool L_0 = ___0_value;
		((ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3_StaticFields*)il2cpp_codegen_static_fields_for(ATLogger_t0B72E697B6B1E29CE4849BB0B165435C2DCC89D3_il2cpp_TypeInfo_var))->___isDebug = L_0;
		return;
	}
}
