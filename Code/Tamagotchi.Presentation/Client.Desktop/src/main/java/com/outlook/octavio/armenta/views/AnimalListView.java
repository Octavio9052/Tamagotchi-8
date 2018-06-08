package com.outlook.octavio.armenta.views;

import com.outlook.octavio.armenta.viewmodels.AnimalListViewModel;
import de.saxsys.mvvmfx.FxmlView;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;

import java.net.URL;
import java.util.ResourceBundle;

public class AnimalListView implements FxmlView<AnimalListViewModel>, Initializable {
    @FXML
    public Button newButton;
    @FXML
    public ListView petsList;

    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }
}
