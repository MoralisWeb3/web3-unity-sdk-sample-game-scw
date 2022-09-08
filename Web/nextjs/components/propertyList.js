import Property from "./property"

export const getStaticProps = async () => {
  return {
    props: { properties : [1,2,3]}
  }
}

export default function PropertyList({ properties }) {
  return (
    <>
      {
        console.log ("is : " + properties)
       
      })}
    </>
  )
}
