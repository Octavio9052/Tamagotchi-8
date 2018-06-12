package com.outlook.octavio.armenta.tamagotchi9052

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.Toast


class AccessMethodFragment : Fragment() {


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    // The onCreateView method is called when Fragment should create its View object hierarchy,
    // either dynamically or via XML layout inflation.
    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_access_method, parent, false)
    }

    // This event is triggered soon after onCreateView().
    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        // Setup any handles to view objects here
        // EditText etFoo = (EditText) view.findViewById(R.id.etFoo);
        super.onViewCreated(view, savedInstanceState)
        // petImageState = view.findViewById(R.id.state_image_pet)

        view.findViewById<Button>(R.id.access_sign_in).setOnClickListener {
            activity!!.supportFragmentManager.beginTransaction().replace(R.id.login_or_register_fragment, LoginFragment()).addToBackStack(null).commit()
        }
        view.findViewById<Button>(R.id.access_sign_up).setOnClickListener {
            activity!!.supportFragmentManager.beginTransaction().replace(R.id.login_or_register_fragment, RegisterFragment()).addToBackStack(null).commit()
        }
    }
}
