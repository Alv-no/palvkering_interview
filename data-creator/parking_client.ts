export const getParkingDetails = async (id: number) => {
	const url = `https://parkreg-open.atlas.vegvesen.no/ws/no/vegvesen/veg/parkeringsomraade/parkeringsregisteret/v1/parkeringsomraade/${id}`;	
	const parkingDetailsResponse = await fetch(url).then(response => response.json()) as ParkingDetailsResponse;

	delete parkingDetailsResponse.aktivVersjon.links;
	delete parkingDetailsResponse.aktivVersjon.handhever;
	return {
		id: parkingDetailsResponse.id,
		...parkingDetailsResponse.aktivVersjon	
	}
}

export interface ParkingDetailsResponse {
  id: number
  parkeringstilbyderId: number
  parkeringstilbyderNavn: string
  parkeringstilbyderOrganisasjonsnummer: string
  breddegrad: number
  lengdegrad: number
  deaktivert: Deaktivert
  aktivVersjon: AktivVersjon
}

export interface Deaktivert {
  deaktivertTidspunkt: string
}

export interface AktivVersjon {
  navn: string
  referanse: string
  adresse: string
  postnummer: string
  poststed: string
  antallAvgiftsbelagtePlasser: number
  antallAvgiftsfriePlasser: number
  antallLadeplasser: number
  antallForflytningshemmede: number
  vurderingForflytningshemmede: string
  aktiveringstidspunkt: string
  sistEndret: string
  skiltplanId: number
  links?: Link[]
  versjonsnummer: number
  sluttidspunkt: string
  opplastetVurderingId: number
  typeParkeringsomrade: string
  innfartsparkering: string
  handhever?: Handhever
}

export interface Link {
  rel: string
  href: string
  hreflang: string
  media: string
  title: string
  type: string
  deprecation: string
}

export interface Handhever {
  organisasjonsnummer: string
  navn: string
}

