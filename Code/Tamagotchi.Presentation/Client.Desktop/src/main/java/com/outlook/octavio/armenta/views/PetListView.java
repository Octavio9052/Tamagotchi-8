package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.PetListViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;

import java.net.URL;
import java.util.ResourceBundle;

public class PetListView implements FxmlView<PetListViewModel>, Initializable {
    @FXML
    public Button newButton;
    @FXML
    public ListView petsList;

    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }
}
