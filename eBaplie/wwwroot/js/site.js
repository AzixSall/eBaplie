
//$(document).ready(function () {
//    $('.table').DataTable({
//        orderable: false
//    });
//});

$(document).ready(function () {
    $('.table').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'excel'
        ]
    });
});



//const loader = new THREE.GLTFLoader();

        //loader.load(
	       // // URL of the model
	       // '/container_20ft/scene.gltf',

	       // // Called when the model is loaded
	       // function ( gltf ) {
		      //  scene.add( gltf.scene );
	       // },

	       // // Called while loading is progressing
	       // function ( xhr ) {
		      //  console.log( ( xhr.loaded / xhr.total * 100 ) + '% loaded' );
	       // },

	       // // Called when loading has errors
	       // function ( error ) {
		      //  console.log( 'An error happened' );
		      //  console.log( error );
	       // }
        //);

//// create a box helper for the cube
                        //var boxHelper2 = new THREE.BoxHelper(highlightedObject);
                        //boxHelper2.material.color.set(0xffff00);

                        //scene.add( boxHelper2 );
                        //// update the box helper
                        //boxHelper2.update();

                        //// Create a glow material for the edges of the BoxHelper
                        //const edgeMaterial = new THREE.MeshBasicMaterial({
                        //  color: 0xffff00,
                        //  side: THREE.BackSide,
                        //  blending: THREE.AdditiveBlending,
                        //  transparent: true
                        //});

                        // // Create a mesh for the edges of the BoxHelper using the glow material
                        //const edgeMesh = new THREE.Mesh(boxHelper2.geometry, edgeMaterial);
                        //edgeMesh.position.copy(boxHelper2.position);

                        //// Add the edge mesh to the scene
                        //scene.add(edgeMesh);

                        //// Create an emissive material for the object being highlighted
                        //const emissiveMaterial = new THREE.MeshStandardMaterial({
                        //  color: 0xffffff,
                        //  emissive: 0xffff00,
                        //  emissiveIntensity: 5
                        //});

                        //// Set the emissive material on the object being highlighted
                        //highlightedObject.material = emissiveMaterial;


        //$('#highlightDgsCheckbox').on('change', function() {
        //    console.log("DGS check change detected");
        //    globalScene.remove();
        //    initializeScene();
        //});