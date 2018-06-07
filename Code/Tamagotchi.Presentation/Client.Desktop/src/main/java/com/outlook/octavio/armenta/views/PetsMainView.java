package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.PetMainViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

import java.net.URL;
import java.util.ResourceBundle;

public class PetsMainView implements FxmlView<PetMainViewModel>, Initializable {
    @FXML
    public Label usernameLabel;
    @FXML
    public Button logOutButton;

    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }
}
