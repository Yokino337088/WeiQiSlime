//
//  ATNativeSelfRenderView.m
//  AnyThinkSDKDemo
//
//  Created by GUO PENG on 2022/5/7.
//  Copyright © 2022 AnyThink. All rights reserved.
//

#import "ATNativeSelfRenderView.h"
#import <AnyThinkSDK/ATImageLoader.h>
#import "ATNativeAdWrapper.h"
#import "ATAutolayoutCategories.h"
#import "ATUnityUtilities.h"
#define random(r, g, b, a) [UIColor colorWithRed:(r)/255.0 green:(g)/255.0 blue:(b)/255.0 alpha:(a)/255.0]

#define randomColor random(arc4random_uniform(256), arc4random_uniform(256), arc4random_uniform(256), arc4random_uniform(256))

@interface ATNativeSelfRenderView()

@property(nonatomic, strong) ATNativeAdOffer *nativeAdOffer;

@end


@implementation ATNativeSelfRenderView

- (void)dealloc{
    NSLog(@"🔥---ATNativeSelfRenderView--销毁");
}

- (instancetype) initWithOffer:(ATNativeAdOffer *)offer{

    if (self = [super init]) {
        
        _nativeAdOffer = offer;
        
        [self addView];
        [self makeConstraintsForSubviews];
        
        [self setupUI];
    }
    return self;
}

- (void)addView{
    
    self.advertiserLabel = [[UILabel alloc]init];
    self.advertiserLabel.font = [UIFont boldSystemFontOfSize:15.0f];
    self.advertiserLabel.textColor = [UIColor blackColor];
    self.advertiserLabel.textAlignment = NSTextAlignmentLeft;
    self.advertiserLabel.userInteractionEnabled = YES;
    self.advertiserLabel.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.advertiserLabel];
        
    self.titleLabel = [[UILabel alloc]init];
    self.titleLabel.font = [UIFont boldSystemFontOfSize:18.0f];
    self.titleLabel.textColor = [UIColor blackColor];
    self.titleLabel.textAlignment = NSTextAlignmentLeft;
    self.titleLabel.userInteractionEnabled = YES;
    self.titleLabel.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.titleLabel];
    
    self.textLabel = [[UILabel alloc]init];
    self.textLabel.font = [UIFont systemFontOfSize:15.0f];
    self.textLabel.textColor = [UIColor blackColor];
    self.textLabel.userInteractionEnabled = YES;
    self.textLabel.numberOfLines = 0;
    self.textLabel.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.textLabel];
    
    self.ctaLabel = [[UILabel alloc]init];
    self.ctaLabel.font = [UIFont systemFontOfSize:15.0f];
    self.ctaLabel.textColor = [UIColor blackColor];
    self.ctaLabel.userInteractionEnabled = YES;
    self.ctaLabel.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.ctaLabel];

    self.ratingLabel = [[UILabel alloc]init];
    self.ratingLabel.font = [UIFont systemFontOfSize:15.0f];
    self.ratingLabel.textColor = [UIColor blackColor];
    self.ratingLabel.userInteractionEnabled = YES;
    self.ratingLabel.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.ratingLabel];
    
    self.iconImageView = [[UIImageView alloc]init];
    self.iconImageView.layer.cornerRadius = 4.0f;
    self.iconImageView.layer.masksToBounds = YES;
    self.iconImageView.contentMode = UIViewContentModeScaleAspectFit;
    self.iconImageView.translatesAutoresizingMaskIntoConstraints = false;
    self.iconImageView.userInteractionEnabled = YES;
    [self addSubview:self.iconImageView];
    
    
    self.mainImageView = [[UIImageView alloc]init];
    self.mainImageView.contentMode = UIViewContentModeScaleAspectFit;
    self.mainImageView.userInteractionEnabled = YES;
    self.mainImageView.translatesAutoresizingMaskIntoConstraints = false;
    [self addSubview:self.mainImageView];
    
    self.dislikeButton = [UIButton buttonWithType:UIButtonTypeCustom];
    self.dislikeButton.translatesAutoresizingMaskIntoConstraints = false;
    self.dislikeButton.backgroundColor = [UIColor whiteColor];
    [self.dislikeButton setImage:[self getCloseImage] forState:0];
    [self addSubview:self.dislikeButton];
}


- (UIImage *)getCloseImage {
    
    NSString *imageBase64String = @"iVBORw0KGgoAAAANSUhEUgAAAEgAAABICAYAAABV7bNHAAAAAXNSR0IArs4c6QAAAIRlWElmTU0AKgAAAAgABQESAAMAAAABAAEAAAEaAAUAAAABAAAASgEbAAUAAAABAAAAUgEoAAMAAAABAAIAAIdpAAQAAAABAAAAWgAAAAAAAABIAAAAAQAAAEgAAAABAAOgAQADAAAAAQABAACgAgAEAAAAAQAAAEigAwAEAAAAAQAAAEgAAAAAYwsr7AAAAAlwSFlzAAALEwAACxMBAJqcGAAAABxpRE9UAAAAAgAAAAAAAAAkAAAAKAAAACQAAAAkAAACiSuooU0AAAJVSURBVHgB5JqhbsMwEECLisqGhldYNNaxqlJRP2CoY8Wjo/ub4UllI5VGy8f6ASMBA0XbvWiuXKtpnOQcO+lJJ8eRY989351dqYNBuzKU5W5EJ6IPogvRx39dS2ureb+U94zlm1vR3glQcA5Hn0RtCHWfmetOdCTaSbGh1IXg+52B1QlQgLkX1YoUX0iMIyVZO8moignGhWhACas0hMKJUa6hsfvYRJ2KJkTNVDQ2iLL1sRFbWxXyPMWoKYKFra3VJlIqRhEuct73PTYHT7mJLOJrUKrj8CGIcISm6nRVu/BFVfoQOS5EtUgib93J+9KnnjaSkXzdxYLsu4H4ho+1ZChfdeko94XijsNHfK0sXbgEus7W7eNrJelz3SmCWKkeXUNquaC8U61P9x0XQlm/9H5ERb/G6DHgONWGl4qRSvRsNpv3/X7/tdvtPufz+YssaAxQb99ElNe6GEWNowc4v5ZkWfYdCtK5tRQ2ozCKVE4udtPikz+GgOTCMWvOZjONiD37M2SpQH+93W4/jLF2qwmpCA5raPggc8DiREbSU6kP4/H4GUNtOOZZA1IRnMPh8LNarV61/JB5Toq1SnoZ46g5ISC1CIdgmYgehZBSiSAzjzakluHA4iTNVOFoQ4oABx7H04zfIEEAMW/TSIoEx/DgfwR5rpkXQdq6kCLDgUVeh6bsdGitCikBODCBTV6MggNiA3whJQIHJgsANf55gfO+Wgap6KIZ4J7jYzNs2gUEyEuQzKXSbiPBAWAOyIek+hhfSBHhGJ/904Pd19QySAnAWf8BAAD///Z/hqsAAAJUSURBVOWaoVLDQBCGT6HqUGgqq3CVnc5U9QFQwVVja3mMGjSamTpMXwBbXB8AU4Gogv1DfyYtuSS929xd2p25WSYkd/992d3bMBhjzCzmWK1Wb98W2263n+PxeB5Tn6wdD9ByuXy1sPm7nAAkcx8DUhM4pBQREtiEB2SDs9vtvgCDYIo+EqQpAE1kBKtDVXCyLHtCzUkIUg5oGApQHRzqSAgS2JgBhbXpm8KhhkQggY25pqi2/KlwqCMBSDeixVzJeKAobe8KhzoiQxIZv4ZipF6ofeFQUyRIeYHe89GvQ1pwIkK6JRx4pJlaBGnDobbAkdQDmKKppNlisXguNnj8GU0g+hxZ0OtFVEHabDYfvvPvnz9IL0IaaEwOkYRCrwWH+qogjUajOe/z8AfpJfPkhjTzPs3W6/U7wcBrwxGNeQTaIPX7/Ufe4+jz7y95ttTu5KpaCrQFhxqLkLDWixh/5+HBwGoqUSSzzxDqCm+z0ctSXAvR8684H9PyjiIA6uiojB6CQhRF+RtRZKiVtYdw6PEN0tUocNVdenIRSJkfXhAk7PVku5RUQ2phr06Giu7dG8kcrmHf9nPYW+2pVUfunOvRyXXHBkvlMySxSMKeVO2c+qNG/Y4LvXOIJPXIOQaJvO1i4YZm1NMg1pNVutRtQys0BzX0Dl1oJqHRuc/RIIqUSzGaoClYSjUBiZMhBVCoNdASNWpswJDnsUAlDaYMGFJvKqPtzwWsMZCRZMSIrlpDVGnCQqR0HkoVNRROvHGcLtgo6lZZ7eL1yf5ePIP/IwgaKT805vxmzF7SHAAAAABJRU5ErkJggg==";
        
    UIImage *closeImage = [UIImage imageWithData:[[NSData alloc] initWithBase64EncodedString:imageBase64String options:NSDataBase64DecodingIgnoreUnknownCharacters]];
    NSLog(@"getCloseImage--%@",closeImage);
    return closeImage;
}


- (void)setupUI{
    
    if (self.nativeAdOffer.nativeAd.icon) {
        self.iconImageView.image = self.nativeAdOffer.nativeAd.icon;
    }
    [[ATImageLoader shareLoader]loadImageWithURL:[NSURL URLWithString:self.nativeAdOffer.nativeAd.iconUrl] completion:^(UIImage *image, NSError *error) {
            
        if (!error) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [self.iconImageView setImage:image];
            });
        }
    }];
    
    
    NSLog(@"🔥----iconUrl:%@",self.nativeAdOffer.nativeAd.iconUrl);

    [[ATImageLoader shareLoader]loadImageWithURL:[NSURL URLWithString:self.nativeAdOffer.nativeAd.imageUrl] completion:^(UIImage *image, NSError *error) {
            
        if (!error) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [self.mainImageView setImage:image];
            });
        }
    }];
    
    
    NSLog(@"🔥----imageUrl:%@",self.nativeAdOffer.nativeAd.imageUrl);
    
    self.advertiserLabel.text = self.nativeAdOffer.nativeAd.advertiser;

    
    self.titleLabel.text = self.nativeAdOffer.nativeAd.title;
  
    self.textLabel.text = self.nativeAdOffer.nativeAd.mainText;
     
    self.ctaLabel.text = self.nativeAdOffer.nativeAd.ctaText;
  
    self.ratingLabel.text = [NSString stringWithFormat:@"%@", self.nativeAdOffer.nativeAd.rating ? self.nativeAdOffer.nativeAd.rating : @""];
}

-(void) makeConstraintsForSubviews {
    
    self.backgroundColor = [UIColor clearColor];// randomColor;

    self.titleLabel.backgroundColor =  [UIColor clearColor];
    
    self.textLabel.backgroundColor =  [UIColor clearColor];
}
-(void) configureMetrics:(NSDictionary *)metrics {
    
    NSDictionary<NSString*, UIView*> *views = @{kNativeAssetTitle:_titleLabel, kNativeAssetText:_textLabel, kNativeAssetCta:_ctaLabel, kNativeAssetRating:_ratingLabel, kNativeAssetAdvertiser:_advertiserLabel, kNativeAssetIcon:_iconImageView, kNativeAssetMainImage:_mainImageView, kNativeAssetDislike:_dislikeButton};
    [views enumerateKeysAndObjectsUsingBlock:^(id  _Nonnull key, id  _Nonnull obj, BOOL * _Nonnull stop) {
        CGRect frame = CGRectFromString(metrics[key][kParsedPropertiesFrameKey]);
        [self addConstraintsWithVisualFormat:[NSString stringWithFormat:@"|-x-[%@(w)]", key] options:0 metrics:@{@"x":@(frame.origin.x), @"w":@(frame.size.width)} views:views];
        [self addConstraintsWithVisualFormat:[NSString stringWithFormat:@"V:|-y-[%@(h)]", key] options:0 metrics:@{@"y":@(frame.origin.y), @"h":@(frame.size.height)} views:views];
        if ([obj respondsToSelector:@selector(setBackgroundColor:)] && [metrics[key] containsObjectForKey:@"background_color"]) [obj setBackgroundColor:[metrics[key][@"background_color"] hasPrefix:@"#"] ? [UIColor colorWithHexString:metrics[key][@"background_color"]] : [UIColor clearColor]];
        if ([obj respondsToSelector:@selector(setTextColor:)] && [metrics[key] containsObjectForKey:@"text_color"]) [obj setTextColor:[UIColor colorWithHexString:metrics[key][@"text_color"]]];
        if ([obj respondsToSelector:@selector(setFont:)] && [metrics[key] containsObjectForKey:@"text_size"] && [metrics[key][@"text_size"] respondsToSelector:@selector(doubleValue)]) [obj setFont:[UIFont systemFontOfSize:[metrics[key][@"text_size"] doubleValue]]];
    }];
    if ([metrics containsObjectForKey:kNativeAssetMedia]) self.mediaView.frame = CGRectFromString(metrics[kNativeAssetMedia][kParsedPropertiesFrameKey]);
    else self.mediaView.frame = CGRectFromString(metrics[kNativeAssetMainImage][kParsedPropertiesFrameKey]);
}
@end
