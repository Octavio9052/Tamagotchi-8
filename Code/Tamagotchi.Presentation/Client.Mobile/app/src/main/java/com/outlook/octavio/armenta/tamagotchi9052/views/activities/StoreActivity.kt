package com.outlook.octavio.armenta.tamagotchi9052.views.activities

import android.os.Bundle
import android.support.design.widget.NavigationView
import android.support.v4.view.GravityCompat
import android.support.v7.app.ActionBarDrawerToggle
import android.support.v7.app.AppCompatActivity
import android.support.v7.widget.LinearLayoutManager
import android.support.v7.widget.RecyclerView
import android.view.MenuItem
import android.view.View
import android.widget.TextView
import android.widget.Toast
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.models.Animal
import com.outlook.octavio.armenta.tamagotchi9052.views.adapters.StoreAdapter
import com.outlook.octavio.armenta.tamagotchi9052.web.messages.MessageResponse
import com.outlook.octavio.armenta.tamagotchi9052.web.services.AnimalService
import com.outlook.octavio.armenta.tamagotchi9052.web.services.WebServiceFactory
import kotlinx.android.synthetic.main.activity_store.*
import kotlinx.android.synthetic.main.app_bar_store.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class StoreActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener {

    private lateinit var recyclerView: RecyclerView
    private lateinit var viewAdapter: RecyclerView.Adapter<*>
    private lateinit var viewManager: RecyclerView.LayoutManager
    private lateinit var emptyView: TextView

    fun getAnimalsList(callback: (response: List<Animal>) -> Any) {
        val apiService = WebServiceFactory().getService(AnimalService::class.java)
        val call = apiService?.getAll()
        var imageDetails: List<Animal>


        call?.enqueue(object : retrofit2.Callback<MessageResponse<List<Animal>>> {

            override fun onResponse(call: Call<MessageResponse<List<Animal>>>?, response: Response<MessageResponse<List<Animal>>>?) {
                imageDetails = response?.body()?.body!!
                callback(imageDetails)
            }

            override fun onFailure(call: Call<MessageResponse<List<Animal>>>?, t: Throwable?) {
            }
        })
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_store)
        emptyView = findViewById(R.id.empty_view)
        recyclerView = findViewById(R.id.my_recycler_view)
        emptyView.visibility = View.INVISIBLE

        viewManager = LinearLayoutManager(this)

        recyclerView = findViewById<RecyclerView>(R.id.my_recycler_view).apply {
            // use this setting to improve performance if you know that changes
            // in content do not change the layout size of the RecyclerView
            setHasFixedSize(true)

            // use a linear layout manager
            layoutManager = viewManager

            // specify an viewAdapter (see also next example)
            // adapter = viewAdapter
        }


        val webServiceFactory = WebServiceFactory().getService(AnimalService::class.java)

        val repos = webServiceFactory?.getAll()?.enqueue(object : Callback<MessageResponse<List<Animal>>> {
            override fun onFailure(call: Call<MessageResponse<List<Animal>>>?, t: Throwable?) {
                Toast.makeText(baseContext, "Couldn't reach server", Toast.LENGTH_LONG).show()
            }

            override fun onResponse(call: Call<MessageResponse<List<Animal>>>?, response: Response<MessageResponse<List<Animal>>>?) {
                if (response?.raw()!!.isSuccessful) {
                    val myDataSet = response.body()?.body
                    if(myDataSet == null) {

                        emptyView.visibility = View.VISIBLE
                        viewAdapter = StoreAdapter(myDataSet)
                        recyclerView.visibility = View.VISIBLE

                        recyclerView.apply {
                            adapter = viewAdapter
                        }

                        } else {
                        recyclerView.visibility = View.INVISIBLE
                        emptyView.visibility = View.VISIBLE
                    }



                } else {
                    Toast.makeText(baseContext, "Couldn't get animals", Toast.LENGTH_LONG).show()
                }
                println(response)
            }
        })



        /*val animal = Animal("Fox", "Likes to read and sleep", "http://i.imgur.com/NNfje00.gif")
        /*val anima2 = Animal("Dog", "Likes to play and eat", "http://i.imgur.com/sumGNLN.gif")
        val anima3 = Animal("Turtle", "Likes to rest and play", "http://i.imgur.com/chU36ua.gif")
        val anima4 = Animal("Cat", "Likes to eat and sleep", "http://i.imgur.com/vRQWS9E.gif")
        myDataSet.add(animal)
        myDataSet.add(anima2)
        myDataSet.add(anima3)
        myDataSet.add(anima1) */ */
        // getAnimalsAvailable




        setSupportActionBar(toolbar_store)

        val toggle = ActionBarDrawerToggle(
                this, drawer_layout_store, toolbar_store, R.string.navigation_drawer_open, R.string.navigation_drawer_close)
        drawer_layout_store.addDrawerListener(toggle)
        toggle.syncState()

        nav_view_store.setNavigationItemSelectedListener(this)
    }


    override fun onNavigationItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.nav_first_fragment -> {
                startActivity(intent.setClass(this, MainActivity::class.java))
            }
        }

        drawer_layout_store.closeDrawer(GravityCompat.START)
        return true
    }

}
