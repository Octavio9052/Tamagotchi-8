package com.outlook.octavio.armenta.tamagotchi9052.views.fragments

import android.os.Bundle
import android.support.v4.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import com.outlook.octavio.armenta.tamagotchi9052.R


class AccessMethodFragment : Fragment() {


    override fun onCreateView(inflater: LayoutInflater, parent: ViewGroup?, savedInstanceState: Bundle?): View? {
        // Defines the xml file for the fragment
        return inflater.inflate(R.layout.fragment_access_method, parent, false)
    }

    // Any view setup should occur here.  E.g., view lookups and attaching view listeners.
    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        view.findViewById<Button>(R.id.access_sign_in).setOnClickListener {
            activity!!.supportFragmentManager
                    .beginTransaction()
                    .replace(R.id.login_or_register_fragment, LoginFragment())
                    .addToBackStack(null)
                    .commit()
        }
        view.findViewById<Button>(R.id.access_sign_up).setOnClickListener {
            activity!!.supportFragmentManager
                    .beginTransaction()
                    .replace(R.id.login_or_register_fragment, RegisterFragment())
                    .addToBackStack(null)
                    .commit()
        }
    }
}
