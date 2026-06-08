<script setup>
import { ref, onMounted } from 'vue'
const days=ref(60);
const total=ref(100);

// Reactive array that will hold patients.
const analytics = ref([])
const fetchdetails=async ()=>{
   const response =
    await fetch(`https://localhost:7205/api/analytics/department?days=${days.value}`)

  // Convert JSON into JavaScript objects.
  analytics.value =
    await response.json()
    var res=0;
    for(var obj of analytics.value){
     res+=obj.total;
      
    }
    total.value=res;

}

// Runs automatically when page loads.
onMounted( () => {

  // Call ASP.NET Core API. – Change the port
 fetchdetails();

})
</script>

<template>

  <h1>CareBridge Patients</h1>
  <div>
     <input
      type="number"
      v-model="days"
      placeholder="no of days "
    />
    <button @click="fetchdetails">search</button>

  </div>
  

  



  <table border="1">

    <tr>
      <th>department Name</th>
      <th>inpatients</th>
      <th>outpatients</th>
      <th>ed</th>
      <th>total</th>

    </tr>

    <!-- Loop through all patients -->

    <tr
      v-for="e in analytics"
      :key="e.departmentName">

      <td>{{ e.departmentName }}</td>
      <td>{{ e.inpatient }}</td>
      <td>{{ e.outpatient }}</td>
      <td>{{ e.ed }}</td>
      <td>{{ e.total }}</td>

    </tr>
    <tr>
      <td>total</td>
      <td>{{ total }}</td>
    </tr>

  </table>

</template>

<style>
table tr:nth-child(2) {
  background-color:lightcoral;
}
</style>


