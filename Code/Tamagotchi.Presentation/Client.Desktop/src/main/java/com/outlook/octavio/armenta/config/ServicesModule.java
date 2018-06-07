package com.outlook.octavio.armenta.config;

import com.google.inject.AbstractModule;
import com.outlook.octavio.armenta.services.AuthService;
import com.outlook.octavio.armenta.services.contracts.IAuthService;

public class ServicesModule extends AbstractModule {
    @Override
    protected void configure() {
        bind(IAuthService.class).to(AuthService.class);
    }
}
