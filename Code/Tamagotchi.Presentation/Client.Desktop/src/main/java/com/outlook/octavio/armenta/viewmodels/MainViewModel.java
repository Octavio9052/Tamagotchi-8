package com.outlook.octavio.armenta.viewmodels;

import com.google.inject.Inject;
import com.outlook.octavio.armenta.services.contracts.IAuthService;
import de.saxsys.mvvmfx.ViewModel;

import java.util.Objects;

public class MainViewModel implements ViewModel {

    public static final String LOGIN_VIEW = "LOGINVIEW";
    public static final String PET_VIEW = "PETVIEW";

    private final IAuthService authService;

    @Inject
    public MainViewModel(IAuthService authService) {
        this.authService = authService;
    }

    public void initialize() {

        authService.userProperty().addListener((observable, oldValue, newValue) -> {
            if (Objects.isNull(newValue)) {
                publish(LOGIN_VIEW);
            } else {
                publish(PET_VIEW);
            }
        });
    }

}
