package com.outlook.octavio.armenta.tamagotchi9052.views.adapters

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import com.bumptech.glide.Glide
import com.outlook.octavio.armenta.tamagotchi9052.R
import com.outlook.octavio.armenta.tamagotchi9052.models.Animal

class StoreAdapter(private val myDataset: ArrayList<Animal>) :
        RecyclerView.Adapter<StoreAdapter.ViewHolder>() {

    // Provide a reference to the views for each data item
    // Complex data items may need more than one view per item, and
    // you provide access to all the views for a data item in a view holder.
    // Each data item is just a string in this case that is shown in a TextView.
    class ViewHolder(val linearLayout: LinearLayout) : RecyclerView.ViewHolder(linearLayout) {
        var mTitle: TextView
        var mDescription: TextView
        var mImgIdle: ImageView

        init {
            mTitle = linearLayout.findViewById<View>(R.id.store_single_animal_name) as TextView
            mDescription = linearLayout.findViewById<View>(R.id.store_single_animal_descriptor) as TextView
            mImgIdle = linearLayout.findViewById<View>(R.id.store_single_animal_image_idle) as ImageView
        }
    }


    // Create new views (invoked by the layout manager)
    override fun onCreateViewHolder(parent: ViewGroup,
                                    viewType: Int): ViewHolder {
        // create a new view
        val v = LayoutInflater.from(parent.context)
                .inflate(R.layout.item_store_single_animal, parent, false) // as LinearLayout
        // set the view's size, margins, paddings and layout parameters

        val vh = ViewHolder(v as LinearLayout)
        return ViewHolder(v)
    }



    // Replace the contents of a view (invoked by the layout manager)
    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        // - get element from your dataset at this position
        // - replace the contents of the view with that element
        // holder.textView.text = myDataset[position]
        holder.mTitle.text = myDataset[position].name
        holder.mDescription.text = myDataset[position].description
        Glide.with(holder.itemView.context).load(myDataset[position].idleUri).into(holder.mImgIdle)


        holder.itemView.setOnClickListener(object : View.OnClickListener{
            override fun onClick(v: View?) {
                Toast.makeText(v!!.context, "" + holder.mTitle.text + " : " + holder.mDescription.text, Toast.LENGTH_SHORT).show()
            }
        })
    }

    // Return the size of your dataset (invoked by the layout manager)
    override fun getItemCount() = myDataset.size
}