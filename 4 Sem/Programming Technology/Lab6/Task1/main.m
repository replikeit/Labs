//
//  main.m
//  Task1
//
//  Created by khuglar on 06.04.2020.
//  Copyright © 2020 khuglar. All rights reserved.
//

#import <Foundation/Foundation.h>

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        
        int fac;
        NSLog(@"Input a number: ");
        scanf("%d", &fac);
        
        if (fac > 10) {
            NSLog(@"Error: The number more than 10\n");
            return -1;
        }
        	
        int res = 1;
        	
        for (unsigned int i = 2; i < fac; i++) {
            res *= i;
        }
        
        NSLog(@"%d! = %d",fac,res);
    }
    return 0;
}
