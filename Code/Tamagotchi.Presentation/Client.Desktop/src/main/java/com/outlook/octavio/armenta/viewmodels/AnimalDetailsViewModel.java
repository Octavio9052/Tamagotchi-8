package com.outlook.octavio.armenta.viewmodels;

import com.outlook.octavio.armenta.ws.SOAPServiceStub;
import com.outlook.octavio.armenta.ws.SOAPServiceStub.MessageResponseOfAnimalModelNuLtuh91;
import de.saxsys.mvvmfx.ViewModel;
import de.saxsys.mvvmfx.utils.commands.Action;
import de.saxsys.mvvmfx.utils.commands.Command;
import de.saxsys.mvvmfx.utils.commands.DelegateCommand;
import javafx.beans.property.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableMap;
import javafx.scene.image.Image;

import java.io.File;
import java.util.HashMap;
import java.util.Map;


public class AnimalDetailsViewModel implements ViewModel {

    public static final String IDLE_BROWSE = "IDLE_BROWSE";
    public static final String PLAY_BROWSE = "PLAY_BROWSE";
    public static final String SLEEP_BROWSE = "SLEEP_BROWSE";
    public static final String EAT_BROWSE = "EAT_BROWSE";
    public static final String PACKAGE_BROWSE = "PACKAGE_BROWSE";

    private ObjectProperty<Image> idleImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> playImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> sleepImage = new SimpleObjectProperty<>();
    private ObjectProperty<Image> eatImage = new SimpleObjectProperty<>();

    private ObjectProperty<File> packageProperty = new SimpleObjectProperty<>();

    private StringProperty nameField = new SimpleStringProperty();
    private StringProperty descriptionField = new SimpleStringProperty();
    private StringProperty packageField = new SimpleStringProperty();
    private StringProperty propName = new SimpleStringProperty();

    private MapProperty<StringProperty, StringProperty> dynamicProps = new SimpleMapProperty<>(FXCollections.observableHashMap());

    private Command idleBrowseCommand;
    private Command playBrowseCommand;
    private Command sleepBrowseCommand;
    private Command eatBrowseCommand;
    private Command packageBrowseCommand;
    private Command addPropCommand;
    private Command createCommand;

    public void initialize() {

        idleBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doIdleBrowse();
            }
        });

        playBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPlayBrowse();
            }
        });

        sleepBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doSleepBrowse();
            }
        });

        eatBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doEatBrowse();
            }
        });

        packageBrowseCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doPackageBrowse();
            }
        });

        createCommand = new DelegateCommand(() -> new Action() {
            @Override
            protected void action() throws Exception {
                doCreate();
            }
        });


    }

    public void doIdleBrowse() throws Exception {
        publish(IDLE_BROWSE);
    }

    public void doPlayBrowse() {
        publish(PLAY_BROWSE);
    }

    public void doSleepBrowse() {
        publish(SLEEP_BROWSE);
    }

    public void doEatBrowse() {
        publish(EAT_BROWSE);
    }

    public void doPackageBrowse() {
        publish(PACKAGE_BROWSE);
    }

    public void doCreate() {
        // TODO: UPLOAD ANIMAL TO SOAP
        try {
            SOAPServiceStub soapServiceStub = new SOAPServiceStub();

            SOAPServiceStub.MessageRequestOfAnimalModelNuLtuh91 mRequestAnimal = new SOAPServiceStub.MessageRequestOfAnimalModelNuLtuh91();
            SOAPServiceStub.AnimalModel animalModel = new SOAPServiceStub.AnimalModel();

            animalModel.setName(getNameField());
            animalModel.setDescription(getDescriptionField());
            // TODO: Conver to base64 string
            ///////
            animalModel.setPacketFile("a");
            animalModel.setIdleImage("a");
            animalModel.setEatImage("a");
            animalModel.setSleepImage("a");
            animalModel.setPlayImage("a");
            //////
            animalModel.setPacketUri("a");
            animalModel.setIdleUri("a");
            animalModel.setEatUri("a");
            animalModel.setSleepUri("a");
            animalModel.setPlayUri("a");
            ////////

            mRequestAnimal.setBody(animalModel);
            // TODO: Access service to get current User and GUID.
            mRequestAnimal.setUserToken(null);

            SOAPServiceStub.CreateAnimal createAnimal = new SOAPServiceStub.CreateAnimal();
            createAnimal.setValue(mRequestAnimal);

            SOAPServiceStub.CreateAnimalResponse caResponse = soapServiceStub.createAnimal(createAnimal);

            System.out.println("Error: " + caResponse.getCreateAnimalResult().getError());


        } catch (Exception e) {
            System.out.println(e.toString());
        }
    }




    public Image getIdleImage() {
        return idleImage.get();
    }

    public ObjectProperty<Image> idleImageProperty() {
        return idleImage;
    }

    public Image getPlayImage() {
        return playImage.get();
    }

    public ObjectProperty<Image> playImageProperty() {
        return playImage;
    }

    public Image getSleepImage() {
        return sleepImage.get();
    }

    public ObjectProperty<Image> sleepImageProperty() {
        return sleepImage;
    }

    public Image getEatImage() {
        return eatImage.get();
    }

    public ObjectProperty<Image> eatImageProperty() {
        return eatImage;
    }

    public File getPackageProperty() {
        return packageProperty.get();
    }

    public ObjectProperty<File> packagePropertyProperty() {
        return packageProperty;
    }

    public String getNameField() {
        return nameField.get();
    }

    public StringProperty nameFieldProperty() {
        return nameField;
    }

    public String getDescriptionField() {
        return descriptionField.get();
    }

    public StringProperty descriptionFieldProperty() {
        return descriptionField;
    }

    public String getPackageField() {
        return packageField.get();
    }

    public StringProperty packageFieldProperty() {
        return packageField;
    }

    public String getPropName() {
        return propName.get();
    }

    public StringProperty propNameProperty() {
        return propName;
    }

    public ObservableMap<StringProperty, StringProperty> getDynamicProps() {
        return dynamicProps.get();
    }

    public MapProperty<StringProperty, StringProperty> dynamicPropsProperty() {
        return dynamicProps;
    }

    public Command getIdleBrowseCommand() {
        return idleBrowseCommand;
    }

    public Command getPlayBrowseCommand() {
        return playBrowseCommand;
    }

    public Command getSleepBrowseCommand() {
        return sleepBrowseCommand;
    }

    public Command getEatBrowseCommand() {
        return eatBrowseCommand;
    }

    public Command getPackageBrowseCommand() {
        return packageBrowseCommand;
    }

    public Command getAddPropCommand() {
        return addPropCommand;
    }

    public Command getCreateCommand() {
        return createCommand;
    }
}
