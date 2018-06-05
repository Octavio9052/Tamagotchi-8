package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.LoginViewModel;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

import java.net.URL;
import java.util.ResourceBundle;

public class LoginView implements FxmlView<LoginViewModel>, Initializable  {

    @FXML
    private Label helloLabel;

    @FXML
    private Button loginButton;

    @InjectViewModel
    private LoginViewModel viewModel;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        // helloLabel.textProperty().bind(viewModel.helloMessageProperty());
    }
}