package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.LoginViewModel;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;

import java.net.URL;
import java.util.ResourceBundle;

public class LoginView implements FxmlView<LoginViewModel>, Initializable {

    @FXML
    public TextField passwordField;
    @FXML
    public Button loginButton;
    @FXML
    public TextField emailField;

    @InjectViewModel
    private LoginViewModel viewModel;

    public void initialize(URL url, ResourceBundle resourceBundle) {

    }
}