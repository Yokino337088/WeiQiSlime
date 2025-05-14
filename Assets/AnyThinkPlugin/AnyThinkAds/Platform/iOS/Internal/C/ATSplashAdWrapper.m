//
//  ATSplashAdWrapper.m
//  UnityFramework
//
//  Created by li zhixuan on 2023/5/4.
//

#import "ATSplashAdWrapper.h"
#import "ATUnityUtilities.h"
#import <AnyThinkSplash/AnyThinkSplash.h>

@interface ATSplashAdWrapper () <ATSplashDelegate>

@end

@implementation ATSplashAdWrapper

+ (instancetype)sharedInstance {
    static ATSplashAdWrapper *sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[ATSplashAdWrapper alloc] init];
    });
    return sharedInstance;
}

- (NSString *)scriptWrapperClass {
    return @"ATSplashAdWrapper";
}

- (id)selWrapperClassWithDict:(NSDictionary *)dict callback:(void(*)(const char*, const char*))callback {
    NSString *selector = dict[@"selector"];
    NSArray<NSString*>* arguments = dict[@"arguments"];
    NSString *firstObject = @"";
    NSString *lastObject = @"";
    if (![ATUnityUtilities isEmpty:arguments]) {
        for (int i = 0; i < arguments.count; i++) {
            if (i == 0) { firstObject = arguments[i]; }
            else { lastObject = arguments[i]; }
        }
    }
    
    if ([selector isEqualToString:@"loadSplashAdWithPlacementID:customDataJSONString:callback:"]) {
        [self loadSplashAdWithPlacementID:firstObject customDataJSONString:lastObject callback:callback];
    } else if ([selector isEqualToString:@"splashAdReadyForPlacementID:"]) {
        return [NSNumber numberWithBool:[self splashAdReadyForPlacementID:firstObject]];
    } else if ([selector isEqualToString:@"showSplashAdWithPlacementID:extraJsonString:"]) {
        [self showSplashAdWithPlacementID:firstObject extraJsonString:lastObject];
    } else if ([selector isEqualToString:@"checkAdStatus:"]) {
        return [self checkAdStatus:firstObject];
    } else if ([selector isEqualToString:@"clearCache"]) {
        [self clearCache];
    } else if ([selector isEqualToString:@"getValidAdCaches:"]) {
        return [self getValidAdCaches:firstObject];
    }else if ([selector isEqualToString:@"entryScenarioWithPlacementID:scenarioID:"]) {
        [self entryScenarioWithPlacementID:firstObject scenarioID:lastObject];
    }
    
    return nil;
}

- (void)loadSplashAdWithPlacementID:(NSString*)placementID customDataJSONString:(NSString*)customDataJSONString callback:(void(*)(const char*, const char*))callback {
    
    [self setCallBack:callback forKey:placementID];
    NSMutableDictionary *extra = [NSMutableDictionary dictionary];
    if ([customDataJSONString isKindOfClass:[NSString class]] && [customDataJSONString length] > 0) {
        NSDictionary *extraDict = [NSJSONSerialization JSONObjectWithData:[customDataJSONString dataUsingEncoding:NSUTF8StringEncoding] options:NSJSONReadingAllowFragments error:nil];
        [extra addEntriesFromDictionary:extraDict];
    }
    NSString *defaultAdSourceConfig = extra[@"default_adSource_config"];
    NSLog(@"ATSplashAdWrapper::extra = %@", extra);
    [[ATAdManager  sharedManager] loadADWithPlacementID:placementID extra:extra delegate:self containerView:nil];
}


- (BOOL)splashAdReadyForPlacementID:(NSString*)placementID {
    return [[ATAdManager sharedManager] splashReadyForPlacementID:placementID];
}

- (NSString*)getValidAdCaches:(NSString *)placementID {
    NSArray *array = [[ATAdManager sharedManager] getSplashValidAdsForPlacementID:placementID];
    NSLog(@"ATSplashAdWrapper::array = %@", array);
    return array.jsonFilterString;
}

- (void)showSplashAdWithPlacementID:(NSString*)placementID extraJsonString:(NSString*)extraJsonString {
    [[ATAdManager sharedManager] showSplashWithPlacementID:placementID scene:@"" window:[UIApplication sharedApplication].delegate.window delegate:self];
}

- (NSString*)checkAdStatus:(NSString *)placementID {
    ATCheckLoadModel *checkLoadModel = [[ATAdManager sharedManager] checkSplashLoadStatusForPlacementID:placementID];
    NSMutableDictionary *statusDict = [NSMutableDictionary dictionary];
    statusDict[@"isLoading"] = @(checkLoadModel.isLoading);
    statusDict[@"isReady"] = @(checkLoadModel.isReady);
    statusDict[@"adInfo"] = checkLoadModel.adOfferInfo;
    NSLog(@"ATSplashAdWrapper::statusDict = %@", statusDict);
    return statusDict.jsonFilterString;
}

- (void)entryScenarioWithPlacementID:(NSString *)placementID scenarioID:(NSString *)scenarioID{
    [[ATAdManager sharedManager] entrySplashScenarioWithPlacementID:placementID scene:scenarioID];
}

- (void) clearCache {

}

#pragma mark - ATSplashDelegate
/// Splash ad displayed successfully
- (void)splashDidShowForPlacementID:(NSString *)placementID
                              extra:(NSDictionary *)extra {
    [self invokeCallback:@"OnSplashAdShow" placementID:placementID error:nil extra:extra];
}

/// Splash ad click
- (void)splashDidClickForPlacementID:(NSString *)placementID
                               extra:(NSDictionary *)extra {
    [self invokeCallback:@"OnSplashAdClick" placementID:placementID error:nil extra:extra];
}

/// Splash ad closed
- (void)splashDidCloseForPlacementID:(NSString *)placementID
                               extra:(NSDictionary *)extra {
    [self invokeCallback:@"OnSplashAdClose" placementID:placementID error:nil extra:extra];
}

/// Callback when the splash ad is loaded successfully
/// @param isTimeout whether timeout
/// v 5.7.73
- (void)didFinishLoadingSplashADWithPlacementID:(NSString *)placementID
                                      isTimeout:(BOOL)isTimeout {
}

/// Splash ad loading timeout callback
/// v 5.7.73
- (void)didTimeoutLoadingSplashADWithPlacementID:(NSString *)placementID {
    [self invokeCallback:@"OnSplashAdLoadTimeout" placementID:placementID error:nil extra:nil];
}

/// Splash ad failed to display
/// currently supports Pangle, Guangdiantong and Baidu
- (void)splashDidShowFailedForPlacementID:(NSString *)placementID
                                    error:(NSError *)error
                                    extra:(NSDictionary *)extra {
    [self invokeCallback:@"OnSplashAdFailedToShow" placementID:placementID error:error extra:extra];
}

///  Whether the click jump of Splash ad is in the form of Deeplink
/// note: only suport TopOn Adx ad
- (void)splashDeepLinkOrJumpForPlacementID:(NSString *)placementID
                                     extra:(NSDictionary *)extra
                                    result:(BOOL)success {
    NSMutableDictionary *newExtra = [[NSMutableDictionary alloc] initWithDictionary:extra];
    newExtra[@"success"] = @(success);
    [self invokeCallback:@"OnSplashAdDeeplink" placementID:placementID error:nil extra:newExtra];
}

///  Splash ad closes details page
- (void)splashDetailDidClosedForPlacementID:(NSString *)placementID
                                      extra:(NSDictionary *)extra {
    
}

/// Called when splash zoomout view did click
/// note: only suport Pangle splash zoomout view and the Tencent splash V+ ad
- (void)splashZoomOutViewDidClickForPlacementID:(NSString *)placementID
                                          extra:(NSDictionary *)extra {
    
}

/// Called when splash zoomout view did close
/// note: only suport Pangle splash zoomout view and the Tencent splash V+ ad
- (void)splashZoomOutViewDidCloseForPlacementID:(NSString *)placementID
                                          extra:(NSDictionary *)extra {
    
}

/// This callback is triggered when the skip button is customized.
/// note: only suport TopOn MyOffer, TopOn Adx and TopOn OnlineApi
/// 5.7.61+
- (void)splashCountdownTime:(NSInteger)countdown
             forPlacementID:(NSString *)placementID
                      extra:(NSDictionary *)extra {
    
}

#pragma mark - ATAdLoadingDelegate
/// Callback when the successful loading of the ad
- (void)didFinishLoadingADWithPlacementID:(NSString *)placementID {
    [self invokeCallback:@"OnSplashAdLoaded" placementID:placementID error:nil extra:nil];
}

/// Callback of ad loading failure
- (void)didFailToLoadADWithPlacementID:(NSString*)placementID
                                 error:(NSError*)error {
    error = error != nil ? error : [NSError errorWithDomain:@"com.anythink.Unity3DPackage" code:100001 userInfo:@{NSLocalizedDescriptionKey:@"AT has failed to load ad", NSLocalizedFailureReasonErrorKey:@"AT has failed to load ad"}];
    [self invokeCallback:@"OnSplashAdLoadFailure" placementID:placementID error:error extra:nil];
    
}

/// Ad start load
- (void)didStartLoadingADSourceWithPlacementID:(NSString *)placementID
                                         extra:(NSDictionary*)extra {
    [self invokeCallback:@"startLoadingADSource" placementID:placementID error:nil extra:extra];
    
}
/// Ad load success
- (void)didFinishLoadingADSourceWithPlacementID:(NSString *)placementID
                                          extra:(NSDictionary*)extra {
    [self invokeCallback:@"finishLoadingADSource" placementID:placementID error:nil extra:extra];
    
}
/// Ad load fail
- (void)didFailToLoadADSourceWithPlacementID:(NSString*)placementID
                                       extra:(NSDictionary*)extra
                                       error:(NSError*)error {
    [self invokeCallback:@"failToLoadADSource" placementID:placementID error:error extra:extra];
}

/// Ad start bidding
- (void)didStartBiddingADSourceWithPlacementID:(NSString *)placementID
                                         extra:(NSDictionary*)extra {
    [self invokeCallback:@"startBiddingADSource" placementID:placementID error:nil extra:extra];
}

/// Ad bidding success
- (void)didFinishBiddingADSourceWithPlacementID:(NSString *)placementID
                                          extra:(NSDictionary*)extra {
    [self invokeCallback:@"finishBiddingADSource" placementID:placementID error:nil extra:extra];
}

/// Ad bidding fail
- (void)didFailBiddingADSourceWithPlacementID:(NSString*)placementID
                                        extra:(NSDictionary*)extra
                                        error:(NSError*)error {
    [self invokeCallback:@"failBiddingADSource" placementID:placementID error:error extra:extra];
}

@end
