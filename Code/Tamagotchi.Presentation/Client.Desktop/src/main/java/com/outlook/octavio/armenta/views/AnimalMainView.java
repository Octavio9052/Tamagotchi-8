package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.AnimalMainViewModel;
import de.saxsys.mvvmfx.FxmlView;
import de.saxsys.mvvmfx.InjectViewModel;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

import java.net.URL;
import java.util.ResourceBundle;

public class AnimalMainView implements FxmlView<AnimalMainViewModel>, Initializable {

    @FXML
    public Label usernameLabel;
    @FXML
    public Button logOutButton;

    @InjectViewModel
    private AnimalMainViewModel viewModel;



    @Override
    public void initialize(URL location, ResourceBundle resources) {
        logOutButton.setOnAction(e -> viewModel.getLogoutCommand().execute());
        usernameLabel.textProperty().bind(viewModel.userNameProperty());
    }
}
