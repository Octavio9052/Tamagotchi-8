package com.outlook.octavio.armenta.tamagotchi9052.fragments

import android.content.Intent
import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.activities.MainActivity

class RegisterFragment : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_register, parent, false)
    }

    // This event is triggered soon after onCreateView().
    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // EditText etFoo = (EditText) view.findViewById(R.id.etFoo);
        super.onViewCreated(view, savedInstanceState)
        // petImageState = view.findViewById(R.id.state_image_pet)

        view.findViewById<Button>(R.id.register_create_account).setOnClickListener { doRegister() }
    }

    fun doRegister() {
        attempLogin()
    }

    fun attempLogin() {
        if(checkCredential()){
            doLogin()
        }
        else {

        }
    }

    fun checkCredential(): Boolean {
        return true
    }

    fun doLogin() {
        val intent = Intent(activity, MainActivity::class.java)
        startActivity(intent)
    }

    fun getToken() {

    }

    fun getUser() {

    }
}
